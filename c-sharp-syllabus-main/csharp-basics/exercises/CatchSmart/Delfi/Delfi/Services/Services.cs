using System.Xml;
using System.Xml.Linq;

namespace Delfi;

public class Services
{
    private static IHttpClientFactory _clientFactory;
    private static IWebHostEnvironment _webHostEnvironment;

    public Services(IHttpClientFactory clientFactory, IWebHostEnvironment webHostEnvironment)
    {
        _clientFactory = clientFactory;
        _webHostEnvironment = webHostEnvironment;
    }

    public static async Task<XDocument> GetXmlContent(string url)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Ignore;
        var xmlReader = XmlReader.Create(url, settings);
        return XDocument.Load(xmlReader, LoadOptions.None);
    }

    public static List<FeedItem> ParseXmlItems(XDocument xml, int amount)
    {
        XNamespace mediaNamespace = "http://search.yahoo.com/mrss/";
        return xml.Descendants("item")
            .Take(amount)
            .Select(item => new FeedItem
            {
                Title = item.Element("title").Value,
                Link = item.Element("link").Value,
                Description = item.Element("description").Value,
                PubDate = DateTime.Parse(item.Element("pubDate").Value),
                Category = item.Element("category").Value,
                ImageUrl = item.Element(mediaNamespace + "content").Attribute("url").Value
            })
            .ToList();
    }

    public static string UploadPhoto(IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var random = Guid.NewGuid() + fileName;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Images/UserPhotos", random);
            var filePathToSave = "UserPhotos/" + random;
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            using var fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);

            return random;
        }

        return "ebc3bf16-564b-4737-b010-c39dd9bf3234nofile.png";
    }
}
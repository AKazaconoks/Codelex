using System.Text.Json.Serialization;

public class Holiday
{
    [JsonPropertyName("date")]
    public string Date { get; set; }
    
    [JsonPropertyName("localName")]
    public string LocalName { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
    
    [JsonPropertyName("fixed")]
    public bool Fixed { get; set; }
    
    [JsonPropertyName("global")]
    public bool Global { get; set; }
    
    [JsonPropertyName("counties")]
    public List<string> Counties { get; set; }
    
    [JsonPropertyName("launchYear")]
    public int? LaunchYear { get; set; }
    
    [JsonPropertyName("types")]
    public List<string> Types { get; set; }
    
    public Holiday()
    {
        // Default constructor
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using ITableEntity = Microsoft.Azure.Cosmos.Table.ITableEntity;

namespace Atea
{
    public class Timer
    {
        private static HttpClient _client = new HttpClient();
        private static CloudStorageAccount _storageAccount =
            CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

        [FunctionName("TimerTrigger")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

                var response = await _client.GetAsync("https://api.publicapis.org/random?auth=null");
                var content = await response.Content.ReadAsStringAsync();

                var tableClient = _storageAccount.CreateCloudTableClient();
                var table = tableClient.GetTableReference("Logs");
                await table.CreateIfNotExistsAsync();

                var logEntity = new LogEntity(Guid.NewGuid().ToString())
                {
                    Timestamp = DateTime.UtcNow,
                    Status = "Success",
                    Message = "Data fetched successfully"
                };

                var insertOperation = TableOperation.Insert(logEntity);
                await table.ExecuteAsync(insertOperation);

                var blobClient = _storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference("data");
                await container.CreateIfNotExistsAsync();

                var blobName = $"{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.json";
                var blob = container.GetBlockBlobReference(blobName);
                await blob.UploadTextAsync(content);

                log.LogInformation($"Data fetched successfully {content}");
            }
            catch (Exception e)
            {
                log.LogError($"Error fetching data: {e}");

                var clientTable = _storageAccount.CreateCloudTableClient();
                var table = clientTable.GetTableReference("Logs");

                var logEntity = new LogEntity(Guid.NewGuid().ToString())
                {
                    Timestamp = DateTime.UtcNow,
                    Status = "Failure",
                    Message = e.Message
                };

                var insertOperation = TableOperation.Insert(logEntity);
                await table.ExecuteAsync(insertOperation);

            }

        }
    }

    public class LogEntity : TableEntity
    {
        public LogEntity(string id)
        {
            PartitionKey = "Log";
            RowKey = id;
        }

        public LogEntity(){}

        public string Status { get; set; }
        public string Message { get; set; }
    }
}

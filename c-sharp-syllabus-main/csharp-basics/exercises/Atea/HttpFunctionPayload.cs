using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea
{
    public static class HttpFunctionPayload
    {
        [FunctionName("GetPayloadHttpFunction")]
        public static async Task<IActionResult> GetPayload(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "payload/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request to get payload of {id}.");

            try
            {
                var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                var storageAccount = CloudStorageAccount.Parse(connectionString);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var logBlobContainer = blobClient.GetContainerReference("data");
                var logBlob = logBlobContainer.GetBlockBlobReference(id);

                if (!await logBlob.ExistsAsync())
                {
                    return new NotFoundObjectResult($"Log entity {id} is not found");
                }

                var content = await logBlob.DownloadTextAsync();
                return new OkObjectResult(content);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error getting payload.");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public class LogEntity : TableEntity
        {
            public LogEntity(string id)
            {
                PartitionKey = "Log";
                RowKey = id;
            }

            public LogEntity() { }

            public string Status { get; set; }
            public string Message { get; set; }
        }
    }
}
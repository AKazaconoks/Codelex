using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;
        private CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LogEntity>> GetLogs(DateTime from, DateTime to)
        {
            try
            {
                var tableClient = storageAccount.CreateCloudTableClient();
                var table = tableClient.GetTableReference("Logs");
                await table.CreateIfNotExistsAsync();

                var query = new TableQuery<LogEntity>()
                    .Where(
                        TableQuery.CombineFilters(
                            TableQuery.GenerateFilterConditionForDate("Timestamp",
                                QueryComparisons.GreaterThanOrEqual, from),
                            TableOperators.And,
                            TableQuery.GenerateFilterConditionForDate("Timestamp",
                                QueryComparisons.LessThanOrEqual, to)));
                var logs = await table.ExecuteQuerySegmentedAsync(query, null);

                return logs.Results;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error retrieving logs");
                throw;
            }
        }

        [HttpGet("{logId}")]
        public async Task<IActionResult> GetLogPayload(string logId)
        {
            try
            {
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference("data");

                var log = await GetLogById(logId);
                if (log == null)
                {
                    return NotFound();
                }

                var blobName = $"{log.Timestamp.ToString("yyyyMMddHHmmss")}.json";
                var blob = container.GetBlockBlobReference(blobName);
                var content = await blob.DownloadTextAsync();

                return Ok(content);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error retrieving log payload");
                throw;
            }
        }

        private async Task<LogEntity> GetLogById(string logId)
        {
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("Logs");
            await table.CreateIfNotExistsAsync();

            var retrieveOperation = TableOperation.Retrieve<LogEntity>("Logs", logId);
            var result = await table.ExecuteAsync(retrieveOperation);
            return result.Result as LogEntity;
        }

        public class LogEntity : TableEntity
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }
    }
}

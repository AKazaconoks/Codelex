using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos.Table;

namespace Atea
{
    public static class HttpFunctionLog
    {
        [FunctionName("GetLogsHttpFunction")]
        public static IActionResult GetLogs(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "logs/{from}/{to}")] HttpRequest req,
            DateTime from,
            DateTime to,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request to get logs from {from} to {to}.");

            try
            {
                var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                var storageAccount = CloudStorageAccount.Parse(connectionString);
                var tableClient = storageAccount.CreateCloudTableClient();
                var table = tableClient.GetTableReference("Logs");

                var filter = TableQuery.CombineFilters(
                    TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, from),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, to));
                var query = new TableQuery<LogEntity>().Where(filter);

                var logs = new List<LogEntity>();
                TableContinuationToken continuationToken = null;
                do
                {
                    var queryResult = table.ExecuteQuerySegmented(query, continuationToken);
                    logs.AddRange(queryResult.Results);
                    continuationToken = queryResult.ContinuationToken;
                } while (continuationToken != null);

                return new OkObjectResult(logs);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error getting logs.");
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
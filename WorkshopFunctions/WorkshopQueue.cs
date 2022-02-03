using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace WorkshopFunctions
{
    public static class WorkshopQueue
    {
        [FunctionName("WorkshopQueue")]
        public static void Run([QueueTrigger("outqueue", Connection = "AzureWebJobsStorage")]string myQueueItem,
                        [Queue("otherqueue"), StorageAccount("AzureWebJobsStorage")] ICollector<string> msg,
                        ILogger log)
        {
            if (!string.IsNullOrEmpty(myQueueItem))
            {
                // Add a message to the output collection.
                msg.Add(string.Format("Queue processed: {0}", myQueueItem));
            }

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}

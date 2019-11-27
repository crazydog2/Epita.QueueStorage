using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace Epita.QueueStorage.ConsoleApp
{
    public class QueueService
    {
        private readonly CloudStorageAccount storageAccount;

        public QueueService(string connectionString)
        {
            storageAccount = CloudStorageAccount.Parse(connectionString);
        }
        
        public async Task EnqueueMessageAsync(string queueName, string content)
        {
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync().ConfigureAwait(false);

            // Should apply base64 encoding
            queue.EncodeMessage = false;

            var message = new CloudQueueMessage(content);

            await queue.AddMessageAsync(message).ConfigureAwait(false);
        }

        public async Task<string> DequeueMessageAsync(string queueName)
        {
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync().ConfigureAwait(false);

            // Should apply base64 encoding
            queue.EncodeMessage = false;

            CloudQueueMessage message = await queue.GetMessageAsync().ConfigureAwait(false);

            return message.AsString;
        }
    }
}
using System;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Configuration;
using Epita.QueueStorage.Services.Contracts;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;

namespace Epita.QueueStorage.Services
{
    public class ComputeService : IComputeService
    {
        private readonly CloudQueueClient queueClient;

        public ComputeService(AzureConfiguration configuration)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(configuration.ConnectionString);

            queueClient = storageAccount.CreateCloudQueueClient();
        }

        public Task LaunchAsync(EventTags eventTags)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
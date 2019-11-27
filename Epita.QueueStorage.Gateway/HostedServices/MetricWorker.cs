using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Services.Configuration;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Hosting;

namespace Epita.QueueStorage.Gateway.HostedServices
{
    public class MetricWorker : BackgroundService
    {
        private readonly IMetricLogic metricLogic;
        private readonly CloudQueueClient queueClient;

        public MetricWorker(
            IMetricLogic metricLogic,
            AzureConfiguration configuration)
        {
            this.metricLogic = metricLogic;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(configuration.ConnectionString);

            queueClient = storageAccount.CreateCloudQueueClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // TODO Replace
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken).ConfigureAwait(false);

                string hostName = Dns.GetHostName();
                string processName = Process.GetCurrentProcess().ProcessName;
                string user = Environment.UserName;
                int pid = Process.GetCurrentProcess().Id;
                
                File.AppendAllLines("tests", new List<string>{$"[{hostName}]:[{processName}]:[{user}]:[{pid}]:[{DateTime.UtcNow}]"});
            }
        }
    }
}
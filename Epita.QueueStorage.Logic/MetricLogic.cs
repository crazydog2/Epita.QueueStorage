using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Logic
{
    public class MetricLogic : IMetricLogic
    {
        private readonly IMetricService metricService;
        private readonly IProcessorService processorService;

        public MetricLogic(
            IMetricService metricService,
            IProcessorService processorService)
        {
            this.metricService = metricService;
            this.processorService = processorService;
        }

        public Task<IDictionary<string, int>> GetAsync(string userId, ISet<string> tags)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public async Task<bool> ProcessAsync(EventTags eventTags)
        {
            // DO NOT REMOVE
            await processorService.ProcessAsync(eventTags.UserId).ConfigureAwait(false);

            // TODO
            throw new System.NotImplementedException();
        }
    }
}
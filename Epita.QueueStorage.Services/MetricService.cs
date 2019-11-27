using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Services
{
    public class MetricService : IMetricService
    {
        public Task<IDictionary<string, int>> GetAsync(string userId, ISet<string> tags)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<bool> ProcessAsync(EventTags eventTags)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;

namespace Epita.QueueStorage.Logic.Contracts
{
    public interface IMetricLogic
    {
        /// <summary>
        /// Returns the number of photos attached to each tags
        /// </summary>
        /// <param name="userId">The owner of the photos</param>
        /// <param name="tags">The list of the tags</param>
        /// <returns>A dictionary with the tag as a key and the number of tags associated</returns>
        Task<IDictionary<string, int>> GetAsync(string userId, ISet<string> tags);

        /// <summary>
        /// Process the eventTags in order to build a thread-safe Index counting the number of occurence of a tag (non-sensitive)
        /// throughout the photos of a user
        /// </summary>
        /// <param name="eventTags"></param>
        /// <returns></returns>
        Task<bool> ProcessAsync(EventTags eventTags);
    }
}
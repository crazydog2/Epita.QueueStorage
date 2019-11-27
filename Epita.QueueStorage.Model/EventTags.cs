using System.Collections.Generic;

namespace Epita.QueueStorage.Model
{
    public class EventTags
    {
        public string UserId { get; set; }

        public string PhotoId { get; set; }

        public Action Action { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
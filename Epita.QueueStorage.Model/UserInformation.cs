using System;
using System.Collections.Generic;

namespace Epita.QueueStorage.Model
{
    public class UserInformation
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public int Age { get; set; }

        public Role Role { get; set; }

        public IEnumerable<Guid> TeamIds { get; set; }
    }
}
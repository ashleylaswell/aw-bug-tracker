using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Entities
{
    public class UserCategory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

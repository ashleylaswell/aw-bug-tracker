using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Entities
{
    public class TicketSeverity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [ForeignKey("TicketSeverityId")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

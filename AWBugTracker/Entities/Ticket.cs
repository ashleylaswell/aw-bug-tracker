using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Entities
{
    public class Ticket
    {
        public Ticket()
        {
            DateTimeTicketCreated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int TicketTypeId { get; set; }
        public int ProgressId { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> TicketTypes { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> Statuses { get; set; }
        public DateTime DateTimeTicketCreated { get; private set; }
    }
}

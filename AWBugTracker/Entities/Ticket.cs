using AWBugTracker.Enums;
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
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Ticket Type")]
        public TicketTypeEnum? TicketType { get; set; }
        [Required]
        [Display(Name = "Ticket Severity")]
        public TicketSeverityEnum? TicketSeverity { get; set; }
        [Required]
        public ProgressEnum? Status { get; set; }

        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}

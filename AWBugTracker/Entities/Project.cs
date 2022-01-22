using AWBugTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Entities
{
    public class Project : IPrimaryProperties
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Thumbnail Image Path")]
        public string ThumbnailImagePath { get; set; }
        [Display(Name = "Created On")]
        public DateTime DateTimeProjectCreated { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<UserCategory> UserCategory { get; set; }
    }
}

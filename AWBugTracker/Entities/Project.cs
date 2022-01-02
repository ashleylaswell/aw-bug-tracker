using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Entities
{
    public class Project
    {
        public Project()
        {
            DateTimeProjectCreated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailImagePath { get; set; }
        public DateTime DateTimeProjectCreated { get; private set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<UserCategory> UserCategory { get; set; }
    }
}

using AWBugTracker.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWBugTracker.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address1 { get; set; }
        [StringLength(250)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string ZipCode { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<UserCategory> UserCateogry { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var timeNow = DateTime.Now;

            foreach (var entry in entries)
            {
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is Project projectTrackable) 
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            projectTrackable.DateTimeProjectCreated = timeNow;
                            break;
                    }
                }
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is Ticket ticketTrackable) 
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            ticketTrackable.ModifiedOn = timeNow;
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            ticketTrackable.CreatedOn = timeNow;
                            ticketTrackable.ModifiedOn = timeNow;
                            break;
                    }
                }
            }
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Project { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
    }
}

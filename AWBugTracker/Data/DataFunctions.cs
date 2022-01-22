using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWBugTracker.Entities;

namespace AWBugTracker.Data
{
    public class DataFunctions : IDataFunctions
    {
        private readonly ApplicationDbContext _context;

        public DataFunctions(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task UpdateUserCategoryEntityAsync(List<UserCategory> userTicketsToDelete, List<UserCategory> userTicketsToAdd)
        {
            using var dbContextTransaction = await _context.Database.BeginTransactionAsync();
            try
            {

                _context.RemoveRange(userTicketsToDelete);
                await _context.SaveChangesAsync();

                if (userTicketsToAdd != null)
                {
                    _context.AddRange(userTicketsToAdd);
                    await _context.SaveChangesAsync();
                }
                await dbContextTransaction.CommitAsync();

            }

            catch (Exception ex)
            {
                await dbContextTransaction.DisposeAsync();
            }
        }
    }
}

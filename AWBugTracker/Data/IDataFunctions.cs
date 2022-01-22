using AWBugTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Data
{
    public interface IDataFunctions
    {
        Task UpdateUserCategoryEntityAsync(List<UserCategory> userTicketsToDelete, List<UserCategory> userTicketsToAdd);
    }
}

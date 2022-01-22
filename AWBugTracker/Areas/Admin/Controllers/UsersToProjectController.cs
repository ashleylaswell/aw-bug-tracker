using AWBugTracker.Areas.Admin.Models;
using AWBugTracker.Data;
using AWBugTracker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersToProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataFunctions _dataFunctions;

        public UsersToProjectController(ApplicationDbContext context, IDataFunctions dataFunctions)
        {
            _context = context;
            _dataFunctions = dataFunctions;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersForProject(int projectId)
        {
            UserCategoryListModel userCategoryListModel = new UserCategoryListModel();

            var allUsers = await GetAllUsers();
            var selectedUsersForProject = await GetSavedSelectedUsersForProject(projectId);

            userCategoryListModel.Users = allUsers;
            userCategoryListModel.UsersSelected = selectedUsersForProject;

            return PartialView("_UsersListViewPartial", userCategoryListModel);

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSelectedUsers([Bind("ProjectId, UsersSelected")] UserCategoryListModel userCategoryListModel)
        {
            List<UserCategory> usersSelectedForProjectToAdd = null;

            if (userCategoryListModel.UsersSelected != null)
            {
                usersSelectedForProjectToAdd = await GetUsersForProjectToAdd(userCategoryListModel);
            }

            var usersSelectedForProjectToDelete = await GetUsersForProjectToDelete(userCategoryListModel.ProjectId);

            await _dataFunctions.UpdateUserCategoryEntityAsync(usersSelectedForProjectToDelete, usersSelectedForProjectToAdd);

            userCategoryListModel.Users = await GetAllUsers();

            return PartialView("_UsersListViewPartial", userCategoryListModel);

        }

        private async Task<List<UserModel>> GetAllUsers()
        {
            var allUsers = await (from user in _context.Users
                                  select new UserModel
                                  {
                                      Id = user.Id,
                                      UserName = user.UserName,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName
                                  }
                                  ).ToListAsync();
            return allUsers;
        }

        private async Task<List<UserCategory>> GetUsersForProjectToAdd(UserCategoryListModel userCategoryListModel)
        {
            var usersForProjectToAdd = (from userCat in userCategoryListModel.UsersSelected
                                         select new UserCategory
                                         {
                                             ProjectId = userCategoryListModel.ProjectId,
                                             UserId = userCat.Id
                                         }).ToList();
            return await Task.FromResult(usersForProjectToAdd);

        }

        private async Task<List<UserCategory>> GetUsersForProjectToDelete(int projectId)
        {
            var usersForProjectToDelete = await(from userCat in _context.UserCategory
                                                 where userCat.ProjectId == projectId
                                                 select new UserCategory
                                                 {
                                                     Id = userCat.Id,
                                                     ProjectId = projectId,
                                                     UserId = userCat.UserId
                                                 }
                                                  ).ToListAsync();
            return usersForProjectToDelete;
        }

        private async Task<List<UserModel>> GetSavedSelectedUsersForProject(int projectId)
        {
            var savedSelectedUsersForProject = await (from usersToCat in _context.UserCategory
                                                       where usersToCat.ProjectId == projectId
                                                       select new UserModel
                                                       {
                                                           Id = usersToCat.UserId
                                                       }).ToListAsync();
            return savedSelectedUsersForProject;
        }
    }
}

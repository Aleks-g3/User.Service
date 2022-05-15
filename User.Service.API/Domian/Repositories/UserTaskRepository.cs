using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Persistence.Contexts;

namespace User.Service.API.Domian.Repositories
{
    public class UserTaskRepository : BaseRepository, IUserTaskRepository
    {
        public UserTaskRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<int> AddAsync(UserTask userTask)
        {
            context.UserTasks.Add(userTask);
            return context.SaveChangesAsync();
        }

        public async Task<IList<UserTask>> GetAllAsync()
        {
            return await context.UserTasks.ToListAsync();
        }

        public Task<UserTask> GetByIDAsync(int userTaskID)
        {
            return context.UserTasks.FirstOrDefaultAsync(t => t.ID == userTaskID);
        }

        public Task<UserTask> GetByTitleAsync(string title)
        {
            return context.UserTasks.FirstOrDefaultAsync(t => t.Title == title && !t.IsDeleted);
        }

        public async Task UpdateAsync(UserTask updateUserTask)
        {
            context.UserTasks.Update(updateUserTask);
            await context.SaveChangesAsync();
        }
    }
}

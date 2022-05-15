using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.API.Domian.Repositories
{
    public interface IUserTaskRepository
    {
        Task<int> AddAsync(UserTask userTask);
        Task UpdateAsync(UserTask updateUserTask);
        Task<IList<UserTask>> GetAllAsync();
        Task<UserTask> GetByIDAsync(int userTaskID);
        Task<UserTask> GetByTitleAsync(string title);
    }
}

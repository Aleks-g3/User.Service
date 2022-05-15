using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.API.Domian.Services
{
    public interface IUserTaskService
    {
        Task<int> AddAsync(int userID, UserTask userTask);
        Task UpdateAsync(int userID, UserTask updateUserTask);
        Task DeleteAsync(int userTaskID);
    }
}

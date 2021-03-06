using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Repositories;

namespace User.Service.API.Domian.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserTaskRepository userTaskRepository;

        public UserTaskService(IUserRepository userRepository, IUserTaskRepository userTaskRepository)
        {
            this.userRepository = userRepository;
            this.userTaskRepository = userTaskRepository;
        }

        public async Task<int> AddAsync(int userID, UserTask userTask)
        {
            var user = await GetUserAsync(userID);

            var existedUserTask = await userTaskRepository.GetByTitleAsync(userTask.Title);

            if (existedUserTask!= null)
            {
                throw new Exception("User Task existed");
            }

            userTask.SetUser(user);

            return await userTaskRepository.AddAsync(userTask);
        }

        public async Task DeleteAsync(int userTaskID)
        {
            var userTask = await GetUserTaskByIDAsync(userTaskID);

            userTask.Delete();

            await userTaskRepository.UpdateAsync(userTask);
        }

        public async Task UpdateAsync(int userID, int userTaskID, UserTask updateUserTask)
        {
            await GetUserAsync(userID);

            var userTask = await GetUserTaskByIDAsync(userTaskID);

            userTask.Update(updateUserTask);

            await userTaskRepository.UpdateAsync(userTask);
        }

        public async Task<IList<UserTask>> GetByUserIDAsync(int userID)
        {
            await GetUserAsync(userID);
            return await userTaskRepository.GetByUserIDAsync(userID);
        }

        public async Task<UserTask> GetByIDAsync(int userID, int userTaskID)
        {
            await GetUserAsync(userID);

            return await GetUserTaskByIDAsync(userTaskID);
        }

        private async Task<UserEntity> GetUserAsync(int userID)
        {
            var user = await userRepository.GetByIDAsync(userID);

            if (user == null)
            {
                throw new Exception("User not existed");
            }

            return user;
        }


        private async Task<UserTask> GetUserTaskByIDAsync(int userTaskID)
        {
            var userTask = await userTaskRepository.GetByIDAsync(userTaskID);

            if (userTask == null)
            {
                throw new Exception("User Task not existed");
            }

            return userTask;
        }
    }
}

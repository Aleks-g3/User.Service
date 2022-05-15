using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Repositories;

namespace User.Service.API.Domian.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<int> AddAsync(UserEntity user)
        {
            var existedUser = await userRepository.GetSpecifiedUser(user.Name, user.Surname);

            if (existedUser != null)
            {
                throw new Exception("User existed");
            }

            if(string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname))
            {
                throw new Exception("Name or surename are empty");
            }

            return await userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(int userID)
        {
            var user = await GetUserAsync(userID);

            user.Delete();

            await userRepository.UpdateAsync(user);
        }

        public async Task UpdateAsync(UserEntity updateUser)
        {
            var user = await GetUserAsync(updateUser.ID);

            if(updateUser.Name==user.Name && updateUser.Surname == user.Surname)
            {
                throw new Exception("Name and surname are equals as for existed user");
            }

            await userRepository.UpdateAsync(updateUser);
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
    }
}

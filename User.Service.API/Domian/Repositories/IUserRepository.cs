using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.API.Domian.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity updateUser);
        Task<UserEntity> GetByIDAsync(int userID);
        Task<UserEntity> GetSpecifiedUser(string name, string surname);
        Task<IList<UserEntity>> GetAllAsync();
    }
}

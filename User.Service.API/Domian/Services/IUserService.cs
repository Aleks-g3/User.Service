using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.API.Domian.Services
{
    public interface IUserService
    {
        Task<int> AddAsync(UserEntity user);
        Task UpdateAsync(UserEntity updateUser);
        Task DeleteAsync(int userID);
    }
}

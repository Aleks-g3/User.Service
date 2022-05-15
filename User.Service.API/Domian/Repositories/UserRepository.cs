using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Domian.Persistence.Contexts;

namespace User.Service.API.Domian.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }
        public Task<int> AddAsync(UserEntity user)
        {
            context.Users.Add(user);
            return context.SaveChangesAsync();
        }

        public async Task<IList<UserEntity>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public Task<UserEntity> GetByIDAsync(int userID)
        {
            return context.Users.FirstOrDefaultAsync(u => u.ID == userID && !u.IsDeleted);
        }

        public Task<UserEntity> GetSpecifiedUser(string name, string surname)
        {
            return context.Users.FirstOrDefaultAsync(u => u.Name == name && u.Surname == surname && !u.IsDeleted);
        }

        public async Task UpdateAsync(UserEntity updateUser)
        {
            context.Users.Update(updateUser);
            await context.SaveChangesAsync();
        }
    }
}

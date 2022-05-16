using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.API.Domian.Models
{
    public class UserEntity : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<UserTask> UserTasks { get; set; } = new List<UserTask>();

        public void Update(UserEntity updateUser)
        {
            if (Name != updateUser.Name)
            {
                Name = updateUser.Name;
            }

            if (Surname != updateUser.Surname)
            {
                Surname = updateUser.Surname;
            }
        }
    }
}

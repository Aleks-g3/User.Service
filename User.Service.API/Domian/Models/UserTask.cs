using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.API.Domian.Models
{
    public class UserTask : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int UserID { get; set; }
        public UserEntity User { get; set; }

        public void SetUser(UserEntity user)
        {
            User = user;
        }

        public void Update(UserTask updateUserTask)
        {
            if(Title != updateUserTask.Title)
            {
                Title = updateUserTask.Title;
            }

            if (Description != updateUserTask.Description)
            {
                Description = updateUserTask.Description;
            }

            if (Deadline != updateUserTask.Deadline)
            {
                Deadline = updateUserTask.Deadline;
            }
        }
    }
}

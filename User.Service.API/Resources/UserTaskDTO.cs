using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.API.Resources
{
    public class UserTaskDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int UserID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.API.Domian.Models
{
    public abstract class Entity
    {
        public int ID { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}

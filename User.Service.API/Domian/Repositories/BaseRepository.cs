using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Persistence.Contexts;

namespace User.Service.API.Domian.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DatabaseContext context;

        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }
    }
}

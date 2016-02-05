using MoviesInfo.Data.Repository;
using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Services
{
    public class StudiosServices
    {
        private IRepository<Studio> studios;

        public StudiosServices(IRepository<Studio> studios)
        {
            this.studios = studios;
        }

        public IQueryable<Studio> All()
        {
            return this.studios.All();
        }
    }
}

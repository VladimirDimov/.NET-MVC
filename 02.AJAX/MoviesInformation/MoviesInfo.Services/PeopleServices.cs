using MoviesInfo.Data.Repository;
using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInfo.Services
{
    public class PeopleServices
    {
        private IRepository<Person> people;

        public PeopleServices(IRepository<Person> people)
        {
            this.people = people;
        }

        public IQueryable<Person> All()
        {
            return this.people.All();
        }
    }
}

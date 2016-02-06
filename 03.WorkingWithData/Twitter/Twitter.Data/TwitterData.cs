using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Repository;
using Twitter.Models;

namespace Twitter.Data
{
    public class TwitterData : ITwitterData
    {
        private TwitterDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TwitterData()
            : this(new TwitterDbContext())
        {
        }

        public TwitterData(TwitterDbContext context)
        {
            this.context = context;
        }

        public IRepository<Twit> Twits
        {
            get
            {
                return this.GetRepository<Twit>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

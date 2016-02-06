using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Repository;
using Twitter.Models;

namespace Twitter.Data
{
    public interface ITwitterData : IDisposable
    {
        IRepository<Twit> Twits { get; }

        IRepository<User> Users { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}

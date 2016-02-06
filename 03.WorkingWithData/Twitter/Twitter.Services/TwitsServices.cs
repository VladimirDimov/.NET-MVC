namespace Twitter.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    public class TwitsServices
    {
        private ITwitterData db;

        public TwitsServices(ITwitterData db)
        {
            this.db = db;
        }

        public IQueryable<Twit> All()
        {
            return this.db.Twits.All();
        }

        public ICollection<Twit> GetByTag(string tagName)
        {
            var allTags = this.db.Tags.All();
            return allTags
                .FirstOrDefault(t => t.Name == tagName)
                .Twits;
        }
    }
}

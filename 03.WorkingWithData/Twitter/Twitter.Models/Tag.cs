namespace Twitter.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        private ICollection<Twit> twits;

        public Tag()
        {
            this.twits = new HashSet<Twit>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Twit> Twits
        {
            get { return this.twits; }
            set { this.twits = value; }
        }
    }
}
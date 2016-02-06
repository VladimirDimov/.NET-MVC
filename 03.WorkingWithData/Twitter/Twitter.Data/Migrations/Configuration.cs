namespace Twitter.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System;
    using Helpers;

    public sealed class Configuration : DbMigrationsConfiguration<Twitter.Data.TwitterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.SeedRoles(context);
            }

            if (!context.Users.Any())
            {
                this.SeedAdmin(context);
                this.SeedUsers(context);
            }

            if (!context.Tags.Any())
            {
                this.SeedTags(context);
            }

            if (!context.Twits.Any())
            {
                this.SeedTwits(context);
            }
        }

        private void SeedUsers(TwitterDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            for (int i = 0; i < 10; i++)
            {
                var user = new User { UserName = $"user_{i}", Email = $"user_{i}@site.com" };

                manager.Create(user, $"User_{i}");
            }

            context.SaveChanges();
        }

        private void SeedTwits(TwitterDbContext context)
        {
            var randomGenerator = new RandomGenerator();
            var allUsers = context.Users.ToList();
            var allTags = context.Tags.ToList();

            for (int i = 0; i < 100; i++)
            {
                var twit = new Twit
                {
                    Author = randomGenerator.GetRandomFrom(allUsers),
                    Message = randomGenerator.GetRandomText(10, 200, true)
                };

                var tags = randomGenerator.GetRandomsFrom(allTags);
                foreach (var tag in tags)
                {
                    twit.Tags.Add(tag);
                }

                context.Twits.Add(twit);
            }

            context.SaveChanges();
        }

        private void SeedTags(TwitterDbContext context)
        {
            var randomGenerator = new RandomGenerator();

            for (int i = 0; i < 20; i++)
            {
                context.Tags.Add(new Tag
                {
                    Name = randomGenerator.GetRandomString(3, 7)
                });
            }

            context.Tags.Add(new Tag { Name = "#fail" });
            context.SaveChanges();
        }

        private void SeedAdmin(TwitterDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = "admin@admin.com", Email = "admin@admin.com" };

            manager.Create(user, "Admin_1");
            manager.ChangePassword(user.Id, "Admin_1", "admin");
            manager.AddToRole(user.Id, "admin");
        }

        private void SeedRoles(TwitterDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "admin" };

            manager.Create(role);
        }
    }
}

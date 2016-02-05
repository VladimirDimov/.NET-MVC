namespace MoviesInfo.Data.Migrations
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesInfo.Data.MoviesInfoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesInfoDbContext context)
        {
            SeedCountries(context);
            SeedCities(context);
        }

        private void SeedCities(MoviesInfoDbContext context)
        {
            foreach (var country in context.Countries)
            {
                for (int i = 0; i < 10; i++)
                {
                    country.Cities.Add(new City { Name = $"Street {i} of {country.Name}" });
                }
            }

            context.SaveChanges();
        }

        private void SeedCountries(MoviesInfoDbContext context)
        {
            var countries = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                context.Countries.Add(new Country { Name = $"Country {i}" });
            }

            context.SaveChanges();
        }
    }
}

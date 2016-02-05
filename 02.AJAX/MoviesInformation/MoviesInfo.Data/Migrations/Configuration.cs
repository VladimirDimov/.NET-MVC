namespace MoviesInfo.Data.Migrations
{
    using Models;
    using Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesInfo.Data.MoviesInfoDbContext>
    {
        private RandomGenerator randomGenerator = new RandomGenerator();
        private Random random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesInfoDbContext context)
        {
            if (!context.People.Any())
            {
                var directors = SeedPeople(context, GetRandomGender(), 10);
                var maleActors = SeedPeople(context, Genders.Male, 20);
                var femaleActors = SeedPeople(context, Genders.Female, 20);
                var studios = SeedStudios(context, 20);
                SeedMovies(context, directors, maleActors, femaleActors, studios);
            }
        }

        private IEnumerable<Studio> SeedStudios(MoviesInfoDbContext context, int number)
        {
            var studios = new List<Studio>();
            for (int i = 0; i < number; i++)
            {
                var studio = new Studio
                {
                    Name = randomGenerator.GetRandomString(2, 10, true),
                    Address = randomGenerator.GetRandomString(10, 20)
                };

                context.Studios.Add(studio);
                studios.Add(studio);
            }

            context.SaveChanges();
            return studios;
        }

        private void SeedMovies(
            MoviesInfoDbContext context,
            IEnumerable<Person> directors,
            IEnumerable<Person> maleActors,
            IEnumerable<Person> femaleActors,
            IEnumerable<Studio> studios)
        {
            for (int i = 0; i < 40; i++)
            {
                context.Movies.Add(new Movie
                {
                    Title = randomGenerator.GetRandomString(2, 30),
                    Year = randomGenerator.GetRandomInt(1950, DateTime.Now.Year),
                    Director = GetRandomFrom(directors.ToList<object>()) as Person,
                    LeadingFemaleRole = GetRandomFrom(femaleActors.ToList<object>()) as Person,
                    LeadingMaleRole = GetRandomFrom(maleActors.ToList<object>()) as Person,
                    Studio = GetRandomFrom(studios.ToList<object>()) as Studio
                });
            }

            context.SaveChanges();
        }

        private object GetRandomFrom(List<object> directors)
        {
            return directors[random.Next(0, directors.Count())];
        }

        private IEnumerable<Person> SeedPeople(MoviesInfoDbContext context, Genders gender, int number)
        {
            var people = new List<Person>();
            for (int i = 0; i < number; i++)
            {
                var person = new Person
                {
                    Age = randomGenerator.GetRandomInt(1, 90),
                    FirstName = randomGenerator.GetRandomString(3, 8, true),
                    LastName = randomGenerator.GetRandomString(3, 8, true),
                    Gender = gender
                };

                context.People.Add(person);
                people.Add(person);
            }

            context.SaveChanges();

            return people;
        }

        private Genders GetRandomGender()
        {
            return random.Next(1, 10) % 2 == 0 ? Genders.Male : Genders.Female;
        }
    }
}

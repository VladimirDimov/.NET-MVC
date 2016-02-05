namespace MoviesInfo.App_Start
{
    using MoviesInfo.Data;
    using MoviesInfo.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesInfoDbContext, Configuration>());
            MoviesInfoDbContext.Create().Database.Initialize(true);
        }
    }
}
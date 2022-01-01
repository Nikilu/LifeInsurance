using Microsoft.EntityFrameworkCore;
using OccupationMicroservice.DBContext;
using System.Threading.Tasks;

namespace OccupationMicroservice.Tests.DbContext
{
    public static class DBContextFactory
    {
        public static async Task<OccupationContext> CreateDB<T>()
        {
            var dbContext = new OccupationContext(
                new DbContextOptionsBuilder<OccupationContext>()
                    .UseInMemoryDatabase(databaseName: typeof(T).FullName).Options);

            dbContext.Database.EnsureDeleted();

            await new OccupationDbInitializer(dbContext)
              .Initialize(recreateDatabase: false, migrateDatabase: false)
              .ConfigureAwait(false);

            return dbContext;
        }
    }
}

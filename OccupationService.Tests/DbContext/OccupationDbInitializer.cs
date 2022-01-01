using Microsoft.EntityFrameworkCore;
using OccupationMicroservice.DBContext;
using System.Threading.Tasks;

namespace OccupationMicroservice.Tests.DbContext
{
    public class OccupationDbInitializer
    {
        private readonly OccupationContext _context;
       
        public OccupationDbInitializer(OccupationContext context)
        {
            _context = context;
        }

        public async Task Initialize(bool recreateDatabase = false, bool migrateDatabase = true)
        {
            if (recreateDatabase)
            {
                await _context.Database.EnsureDeletedAsync();
            }

            if (recreateDatabase || migrateDatabase)
            {
                await _context.Database.MigrateAsync();
            } 
        }
    }
}

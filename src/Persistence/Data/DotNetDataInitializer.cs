using Domain.VirtualMachines;

namespace Persistence.Data
{
    public class DotNetDataInitializer
    {
        private readonly DotNetDbContext _dbContext;

        public DotNetDataInitializer(DotNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //SeedVirtualMachines();
            }
        }

        private void SeedVirtualMachines()
        {
            var products = new VirtualMachineFaker();
        }
    }
}

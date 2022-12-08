using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;

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
                SeedVirtualMachines();
            }
        }

        private void SeedVirtualMachines()
        {
            var virtualMachines = new VirtualMachineFaker()
                .Generate(100); ;

            //_dbContext.VirtualMachines.AddRange(virtualMachines);
            _dbContext.SaveChanges();
        }
    }
}

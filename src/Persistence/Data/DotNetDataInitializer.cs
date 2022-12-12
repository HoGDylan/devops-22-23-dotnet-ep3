using System.Collections.Generic;
using Domain.Common;
using Domain.Projecten;
using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            var Projecten = new ProjectFaker()
                .Generate(1);
            var VirtualMachines = new VirtualMachineFaker().Generate(2);
            /*var virtualMachines1 = new List<VirtualMachine>();
            virtualMachines1.Add(new VirtualMachine(1, "1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Domain.VirtualMachines.BackUp.Backup(Domain.VirtualMachines.BackUp.BackUpType.DAILY, System.DateTime.Now)));
             virtualMachines1.Add(new VirtualMachine(2, "1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Domain.VirtualMachines.BackUp.Backup(Domain.VirtualMachines.BackUp.BackUpType.DAILY, System.DateTime.Now)));
             virtualMachines1.Add(new VirtualMachine(3, "1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Domain.VirtualMachines.BackUp.Backup(Domain.VirtualMachines.BackUp.BackUpType.DAILY, System.DateTime.Now)));
             var project1 = new Project("gegherg");
             project1.VirtualMachines = virtualMachines1;*/
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT VMContracts ON;");
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON;");
            //_dbContext.Entry(virtualMachines).State = EntityState.Detached;
            //_dbContext.SaveChanges();
            //_dbContext.VirtualMachines.AsNoTracking();
            _dbContext.VirtualMachines.AddRange(VirtualMachines);
            //_dbContext.Projecten.AddRange(Projecten);
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT VMContracts OFF;");
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF;");
            _dbContext.SaveChanges();
        }
    }
}

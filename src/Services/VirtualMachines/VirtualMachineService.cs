using Shared.VirtualMachines;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.VirtualMachines;
using System;

namespace Services.VirtualMachines
{
    public class VirtualMachineService : IVirtualMachineService
    {
        public VirtualMachineService(DotNetDbContext dbContext)
        {
            _dbContext = dbContext;
            _virtualMachines = dbContext.VirtualMachines;
        }

        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<VirtualMachine> _virtualMachines;


        private IQueryable<VirtualMachine> GetVirtualMachineById(int id) => _virtualMachines
                .AsNoTracking()
                .Where(p => p.Id == id);

        public async Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request)
        {
            VirtualMachineResponse.Create response = new();
            var virtualMachine = _virtualMachines.Add(new VirtualMachine(
                request.VirtualMachine.Name,
                request.VirtualMachine.Project,
                request.VirtualMachine.OperatingSystem,
                request.VirtualMachine.Mode,
                request.VirtualMachine.Memory,
                request.VirtualMachine.Storage,
                request.VirtualMachine.Amount_vCPU,
                request.VirtualMachine._contract,
                request.VirtualMachine.Connection,
                request.VirtualMachine.Type,
                request.VirtualMachine.LastBackup
            ));
            await _dbContext.SaveChangesAsync();
            response.VirtualMachineId = virtualMachine.Entity.Id;
            return response;
        }

        public async Task DeleteAsync(VirtualMachineRequest.Delete request)
        {
            _virtualMachines.RemoveIf(p => p.Id == request.VirtualMachineId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request)
        {
            VirtualMachineResponse.Edit response = new();
            var virtualMachine = await GetVirtualMachineById(request.VirtualMachineId).SingleOrDefaultAsync();

            if (virtualMachine is not null)
            {
                var model = request.VirtualMachine;

                // You could use a VirtualMachine.Edit method here.
                virtualMachine.Name = model.Name;
                virtualMachine.Project = model.Project;
                virtualMachine.OperatingSystem = model.OperatingSystem;
                virtualMachine.Mode = model.Mode;
                virtualMachine.Hardware.Memory = model.Memory;
                virtualMachine.Hardware.Storage = model.Storage;
                virtualMachine.Hardware.Amount_vCPU = model.Amount_vCPU;
                virtualMachine._contract = model._contract;
                virtualMachine.Connection = model.Connection;
                virtualMachine.BackUp.Type = model.Type;
                virtualMachine.BackUp.LastBackup = model.LastBackup;


                _dbContext.Entry(virtualMachine).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.VirtualMachineId = virtualMachine.Id;
            }

            return response;
        }


        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            VirtualMachineResponse.GetDetail response = new();
            response.VirtualMachine = await GetVirtualMachineById(request.VirtualMachineId)
                .Select(x => new VirtualMachineDto.Detail
                {
                    Id = x.Id,
                    Name = x.Name,
                    Project = x.Project,
                    OperatingSystem = x.OperatingSystem,
                    Mode = x.Mode,
                    Memory = x.Hardware.Memory,
                    Storage = x.Hardware.Storage,
                    Amount_vCPU = x.Hardware.Amount_vCPU,
                    _contract = x._contract,
                    Connection = x.Connection,
                    Type = x.BackUp.Type,
                    LastBackup = (DateTime)x.BackUp.LastBackup
                })
                .SingleOrDefaultAsync();
            return response;
        }

        public async Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            VirtualMachineResponse.GetIndex response = new();
            var query = _virtualMachines.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));


            if (request.OnlyActiveVirtualMachines)
                query = query.Where(x => x.IsEnabled);

            response.TotalAmount = query.Count();

            query.OrderBy(x => x.Name);
            response.VirtualMachines = await query.Select(x => new VirtualMachineDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Project = x.Project,
                OperatingSystem = x.OperatingSystem,
                Mode = x.Mode,
                Memory = x.Hardware.Memory,
                Storage = x.Hardware.Storage,
                Amount_vCPU = x.Hardware.Amount_vCPU,
                _contract = x._contract,
                Connection = x.Connection,
                Type = x.BackUp.Type,
                LastBackup = (DateTime)x.BackUp.LastBackup
            }).ToListAsync();
            return response;
        }
    }
}

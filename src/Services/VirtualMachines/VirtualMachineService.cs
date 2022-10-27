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
                request.VirtualMachine.Name
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

            query = query.Take(request.Amount);
            query = query.Skip(request.Amount * request.Page);

            query.OrderBy(x => x.Name);
            response.VirtualMachines = await query.Select(x => new VirtualMachineDto.Index
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return response;
        }
    }
}

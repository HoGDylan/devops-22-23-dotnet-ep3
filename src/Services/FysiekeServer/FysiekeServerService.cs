using Shared.FysiekeServers;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Server;
using System;
using Domain.Common;

namespace Services.FysiekeServers
{
    public class FysiekeServerService : IFysiekeServerService
    {
        public FysiekeServerService(DotNetDbContext dbContext)
        {
            _dbContext = dbContext;
            _fysiekeServers = dbContext.FysiekeServers;
        }

        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<FysiekeServer> _fysiekeServers;


        private IQueryable<FysiekeServer> GetFysiekeServerById(int id) => _fysiekeServers
                .AsNoTracking()
                .Where(p => p.Id == id);

        public async Task<FysiekeServerResponse.Create> CreateAsync(FysiekeServerRequest.Create request)
        {
            FysiekeServerResponse.Create response = new();
            var fysiekeServer = _fysiekeServers.Add(new FysiekeServer(
                request.FysiekeServer.Name,
                new Hardware(request.FysiekeServer.Memory, request.FysiekeServer.Storage, request.FysiekeServer.Amount_vCPU)
                ,request.FysiekeServer.ServerAddress
             ));
            await _dbContext.SaveChangesAsync();
            response.FysiekeServerId = fysiekeServer.Entity.Id;
            return response;
        }

        public async Task DeleteAsync(FysiekeServerRequest.Delete request)
        {
            _fysiekeServers.RemoveIf(p => p.Id == request.FysiekeServerId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FysiekeServerResponse.Edit> EditAsync(FysiekeServerRequest.Edit request)
        {
            FysiekeServerResponse.Edit response = new();
            var fysiekeServer = await GetFysiekeServerById(request.FysiekeServerId).SingleOrDefaultAsync();

            if (fysiekeServer is not null)
            {
                var model = request.FysiekeServer;

                // You could use a FysiekeServer.Edit method here.
                fysiekeServer.Name = model.Name;
                fysiekeServer.ServerAddress = model.ServerAddress;
                fysiekeServer.HardWare.Memory = model.Memory;
                fysiekeServer.HardWare.Storage = model.Storage;
                fysiekeServer.HardWare.Amount_vCPU = model.Amount_vCPU;
                fysiekeServer.HardWareAvailable.Memory = model.MemoryAvailable;
                fysiekeServer.HardWareAvailable.Storage = model.StorageAvailable;
                fysiekeServer.HardWareAvailable.Amount_vCPU = model.VCPUsAvailable;



                _dbContext.Entry(fysiekeServer).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.FysiekeServerId = fysiekeServer.Id;
            }

            return response;
        }


        public async Task<FysiekeServerResponse.GetDetail> GetDetailAsync(FysiekeServerRequest.GetDetail request)
        {
            FysiekeServerResponse.GetDetail response = new();
            response.FysiekeServer = await GetFysiekeServerById(request.FysiekeServerId)
                .Select(x => new FysiekeServerDto.Detail
                {
                    Id = x.Id,
                    Name = x.Name,
                    ServerAddress = x.ServerAddress,
                    Memory = x.HardWare.Memory,
                    Storage = x.HardWare.Storage,
                    Amount_vCPU = x.HardWare.Amount_vCPU,
                    MemoryAvailable = x.HardWareAvailable.Memory,
                    StorageAvailable = x.HardWareAvailable.Storage,
                    VCPUsAvailable = x.HardWareAvailable.Amount_vCPU,

                })
                .SingleOrDefaultAsync();
            return response;
        }

        public async Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request)
        {
            FysiekeServerResponse.GetIndex response = new();
            var query = _fysiekeServers.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));
            response.TotalAmount = query.Count();

            query.OrderBy(x => x.Name);
            response.FysiekeServers = await query.Select(x => new FysiekeServerDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                ServerAddress = x.ServerAddress,
                Memory = x.HardWare.Memory,
                Storage = x.HardWare.Storage,
                Amount_vCPU = x.HardWare.Amount_vCPU,
            }).ToListAsync();
            return response;
        }
    }
}

using Domain.Common;
using Domain.VirtualMachines;
using Services.Common;
using Shared.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.VirtualMachines
{
    public class FakeVirtualMachineService : IVirtualMachineService
    {
        private static readonly List<VirtualMachine> virtualMachines = new();
        private readonly IStorageService storageService;

        static FakeVirtualMachineService()
        {
            var virtualMachineFaker = new VirtualMachineFaker();
            virtualMachines = virtualMachineFaker.Generate(50);
        }

        public FakeVirtualMachineService(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            await Task.Delay(100);
            VirtualMachineResponse.GetDetail response = new();
            response.VirtualMachine = virtualMachines.Select(x => new VirtualMachineDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
            }).SingleOrDefault(x => x.Id == request.VirtualMachineId);
            return response;
        }

        public async Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            await Task.Delay(100);
            VirtualMachineResponse.GetIndex response = new();
            var query = virtualMachines.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));


            if (request.OnlyActiveVirtualMachines)
                query = query.Where(x => x.IsEnabled);

            response.TotalAmount = query.Count();

            query = query.Skip(request.Amount * request.Page);
            query = query.Take(request.Amount);

            query.OrderBy(x => x.Name);
            response.VirtualMachines = query.Select(x => new VirtualMachineDto.Index
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return response;
        }

        public async Task DeleteAsync(VirtualMachineRequest.Delete request)
        {
            await Task.Delay(100);
            var p = virtualMachines.SingleOrDefault(x => x.Id == request.VirtualMachineId);
            virtualMachines.Remove(p);
        }

        public async Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request)
        {
           await Task.Delay(100);
            VirtualMachineResponse.Create response = new();

            var model = request.VirtualMachine;
               var imageFilename = Guid.NewGuid().ToString();
            var imagePath = $"{storageService.StorageBaseUri}{imageFilename}";
            var virtualMachine = new VirtualMachine(model.Name)
            {
                Id = virtualMachines.Max(x => x.Id) + 1
            };

            virtualMachines.Add(virtualMachine);
            var uploadUri = storageService.CreateUploadUri(imageFilename);
            response.VirtualMachineId = virtualMachine.Id;
            response.UploadUri = uploadUri;

            return response;
        }

        public async Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request)
        {
            await Task.Delay(100);
            VirtualMachineResponse.Edit response = new();
            var virtualMachine = virtualMachines.SingleOrDefault(x => x.Id == request.VirtualMachineId);

            var model = request.VirtualMachine;


            // You could use a VirtualMachine.Edit method here.
            virtualMachine.Name = model.Name;

            response.VirtualMachineId = virtualMachine.Id;
            return response;
        }
    }

}

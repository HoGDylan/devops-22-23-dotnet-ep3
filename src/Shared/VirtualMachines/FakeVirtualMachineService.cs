using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Domain.VirtualMachines;

namespace Shared.VirtualMachines
{
    public class FakeVirtualMachineService : IVirtualMachineService
    {

        private static readonly List<VirtualMachine> _virtualMachines = new();

        static FakeVirtualMachineService()
        {
            var vmFaker = new VirtualMachineFaker();

            _virtualMachines = vmFaker.Generate(25);
        }

        public Task CreateAsync(VirtualMachineResponse.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VirtualMachineResponse.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task Edit(VirtualMachineResponse.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            await Task.Delay(100);
            VirtualMachineResponse.GetDetail response = new();
            response.VirtualMachine = _virtualMachines.Select(e => new VirtualMachineDto.Detail
            {
                Id = e.Id,
                Name = e.Name,
                BackUp = e.BackUp,
                Connection = e.Connection,
                Contract = e.Contract,
                Hardware = e.Hardware,
                Mode = e.Mode,
                OperatingSystem = e.OperatingSystem,
                Project = e.Project

            }).SingleOrDefault(f => f.Id == request.VirtualMachineId);

            return response;

        }

        public Task<IEnumerable<VirtualMachineResponse.GetIndex>> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }
    }
}

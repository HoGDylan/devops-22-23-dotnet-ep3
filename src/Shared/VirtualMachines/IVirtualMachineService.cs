using Bogus;
using Domain.Common;
using Domain.Users;
using Domain.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VirtualMachines;

public interface IVirtualMachineService
{
    Task<IEnumerable<VirtualMachineResponse.GetIndex>> GetIndexAsync(VirtualMachineRequest.GetIndex request);
    Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request);
    Task DeleteAsync(VirtualMachineResponse.Delete request);
    Task CreateAsync(VirtualMachineResponse.Create request);
    Task Edit(VirtualMachineResponse.Edit request);
}

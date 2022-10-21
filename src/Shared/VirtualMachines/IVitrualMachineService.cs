using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VirtualMachines;

internal interface IVitrualMachineService
{
    Task<IEnumerable<VirtualMachineDto.Index>> GetIndexAsync();
    Task<VirtualMachineDto.Detail> GetDetailAsync(int virtualMachineId);
    Task DeleteAsync(int virtualMachineId);
}

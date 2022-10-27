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
    Task<IEnumerable<VirtualMachineDto.Index>> GetIndexAsync();
    Task<VirtualMachineDto.Detail> GetDetailAsync(int id);
    Task DeleteAsync(int id);
    Task CreateAsync(string name, string project, OperatingSystemEnum os, Hardware h, Backup b);
    Task EditVMInformation(int id, string name, Klant k);
    Task EditVMHardware(int id, OperatingSystem os, Hardware h, Backup b);
}

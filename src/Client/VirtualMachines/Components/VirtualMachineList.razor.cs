using Domain.Common;
using Domain.VirtualMachines.BackUp;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Client.VirtualMachines.Components;

public partial class VirtualMachineList
{


    IQueryable<VirtualMachine> vms = new[]
    {
        new VirtualMachine("Fedora_" ,OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("",OperatingSystemEnum.FEDORA_36, new Hardware(160, 4, 4), new Backup(BackUpType.MONTHLY, new DateTime())),
        new VirtualMachine("",OperatingSystemEnum.WINDOWS_10, new Hardware(200, 8, 16),new Backup(BackUpType.CUSTOM, new DateTime())),
        new VirtualMachine("",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
    }.AsQueryable();


}

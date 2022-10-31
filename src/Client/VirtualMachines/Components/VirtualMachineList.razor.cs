using Domain.Common;
using Domain.VirtualMachines;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Client.VirtualMachines.Components;

public partial class VirtualMachineList
{


    IQueryable<VirtualMachine> vms = new[]
    {
        new VirtualMachine("Fedora_", "Dellaware",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("", "EerstejaarsHoGent",OperatingSystemEnum.FEDORA_36, new Hardware(160, 4, 4), new Backup(BackUpType.MONTHLY, new DateTime())),
        new VirtualMachine("", "TweedejarsHoGent",OperatingSystemEnum.WINDOWS_10, new Hardware(200, 8, 16),new Backup(BackUpType.CUSTOM, new DateTime())),
        new VirtualMachine("", "Apple",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("", "DocentenHoGent",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
        new VirtualMachine("", "HoGent",OperatingSystemEnum.KALI_LINUX, new Hardware(100, 4, 4) ,new Backup(BackUpType.DAILY, null)),
    }.AsQueryable();


}

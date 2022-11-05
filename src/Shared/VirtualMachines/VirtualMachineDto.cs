using Domain.Common;
using Domain.Contract;
using Domain.VirtualMachines;
using FluentValidation;

namespace Shared.VirtualMachines
{
    public static class VirtualMachineDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Project { get; set; }
            public OperatingSystemEnum OperatingSystem { get; set; }
            public VirtualMachineMode Mode { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public VMContract _contract { get; set; }
            public VMConnection Connection { get; set; }
            public BackUpType Type { get; set; }
            public DateTime LastBackup { get; set; }
        }

        public class Detail : Index
        {

        }

        public class Mutate
        {
            public String Name { get; set; }
            public String Project { get; set; }
            public OperatingSystemEnum OperatingSystem { get; set; }
            public VirtualMachineMode Mode { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public VMContract _contract { get; set; }
            public VMConnection Connection { get; set; }
            public BackUpType Type { get; set; }
            public DateTime LastBackup { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().Length(1, 250);
                }
            }

        }

    }
}

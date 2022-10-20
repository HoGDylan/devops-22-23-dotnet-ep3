using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Domain.VirtualMachines;

namespace Domain.VirtualMachines
{
    public class Backup : ValueObject
    {

        public BackUpType Type { get; set; }
        public DateTime? LastBackup { get; set; }        //lastBackup can be null


        public Backup(BackUpType type, DateTime? lastBackup)
        {
            this.Type = Guard.Against.Null(type, nameof(type));
            this.LastBackup = lastBackup;
        }



        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return (int)Type;
            yield return LastBackup.HasValue ? LastBackup.Value.Millisecond : 0;
            
        }
    }
}

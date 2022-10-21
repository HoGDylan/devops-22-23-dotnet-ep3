using Ardalis.GuardClauses;

namespace Domain.VirtualMachines
{
    public class Backup : ValueObject
    {


        private BackUpType _type;

        public BackUpType Type { get { return _type; } set { Guard.Against.Null(_type, nameof(_type)); } }
        public DateTime? LastBackup { get; set; }  //lastBackup can be null


        public Backup(BackUpType type, DateTime? lastBackup)
        {
            this.Type = type;
            this.LastBackup = lastBackup;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return (int)Type;
            yield return LastBackup.HasValue ? LastBackup.Value.Millisecond : 0;
            
        }
    }
}

using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpedition
    {
        public Abpedition()
        {
            Abpfeatures = new HashSet<Abpfeature>();
            Abptenants = new HashSet<Abptenant>();
        }

        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<Abpfeature> Abpfeatures { get; set; }
        public virtual ICollection<Abptenant> Abptenants { get; set; }
    }
}

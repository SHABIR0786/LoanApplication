using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpdynamicentityproperty
    {
        public Abpdynamicentityproperty()
        {
            Abpdynamicentitypropertyvalues = new HashSet<Abpdynamicentitypropertyvalue>();
        }

        public int Id { get; set; }
        public string EntityFullName { get; set; }
        public int DynamicPropertyId { get; set; }
        public int? TenantId { get; set; }

        public virtual Abpdynamicproperty DynamicProperty { get; set; }
        public virtual ICollection<Abpdynamicentitypropertyvalue> Abpdynamicentitypropertyvalues { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpdynamicproperty
    {
        public Abpdynamicproperty()
        {
            Abpdynamicentityproperties = new HashSet<Abpdynamicentityproperty>();
            Abpdynamicpropertyvalues = new HashSet<Abpdynamicpropertyvalue>();
        }

        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string InputType { get; set; }
        public string Permission { get; set; }
        public int? TenantId { get; set; }

        public virtual ICollection<Abpdynamicentityproperty> Abpdynamicentityproperties { get; set; }
        public virtual ICollection<Abpdynamicpropertyvalue> Abpdynamicpropertyvalues { get; set; }
    }
}

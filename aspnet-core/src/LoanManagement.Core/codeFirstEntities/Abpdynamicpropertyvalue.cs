using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpdynamicpropertyvalue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? TenantId { get; set; }
        public int DynamicPropertyId { get; set; }

        public virtual Abpdynamicproperty DynamicProperty { get; set; }
    }
}

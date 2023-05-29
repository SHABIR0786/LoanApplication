using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpdynamicentitypropertyvalue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string EntityId { get; set; }
        public int DynamicEntityPropertyId { get; set; }
        public int? TenantId { get; set; }

        public virtual Abpdynamicentityproperty DynamicEntityProperty { get; set; }
    }
}

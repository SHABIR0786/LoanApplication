using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Borrowertype
    {
        public Borrowertype()
        {
            Additionalincomes = new HashSet<Additionalincome>();
            Addresses = new HashSet<Address>();
            Borroweremploymentinformations = new HashSet<Borroweremploymentinformation>();
            Borrowermonthlyincomes = new HashSet<Borrowermonthlyincome>();
            Borrowers = new HashSet<Borrower>();
            Declarationborroweredemographicsinformations = new HashSet<Declarationborroweredemographicsinformation>();
            Declarations = new HashSet<Declaration>();
            Manualassetentries = new HashSet<Manualassetentry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Additionalincome> Additionalincomes { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Borroweremploymentinformation> Borroweremploymentinformations { get; set; }
        public virtual ICollection<Borrowermonthlyincome> Borrowermonthlyincomes { get; set; }
        public virtual ICollection<Borrower> Borrowers { get; set; }
        public virtual ICollection<Declarationborroweredemographicsinformation> Declarationborroweredemographicsinformations { get; set; }
        public virtual ICollection<Declaration> Declarations { get; set; }
        public virtual ICollection<Manualassetentry> Manualassetentries { get; set; }
    }
}

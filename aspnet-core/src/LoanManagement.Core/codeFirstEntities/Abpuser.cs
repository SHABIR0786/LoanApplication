using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Abpuser
    {
        public Abpuser()
        {
            Abppermissions = new HashSet<Abppermission>();
            AbproleCreatorUsers = new HashSet<Abprole>();
            AbproleDeleterUsers = new HashSet<Abprole>();
            AbproleLastModifierUsers = new HashSet<Abprole>();
            Abpsettings = new HashSet<Abpsetting>();
            AbptenantCreatorUsers = new HashSet<Abptenant>();
            AbptenantDeleterUsers = new HashSet<Abptenant>();
            AbptenantLastModifierUsers = new HashSet<Abptenant>();
            Abpuserclaims = new HashSet<Abpuserclaim>();
            Abpuserlogins = new HashSet<Abpuserlogin>();
            Abpuserroles = new HashSet<Abpuserrole>();
            Abpusertokens = new HashSet<Abpusertoken>();
            InverseCreatorUser = new HashSet<Abpuser>();
            InverseDeleterUser = new HashSet<Abpuser>();
            InverseLastModifierUser = new HashSet<Abpuser>();
        }

        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string AuthenticationSource { get; set; }
        public string UserName { get; set; }
        public int? TenantId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string EmailConfirmationCode { get; set; }
        public string PasswordResetCode { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsActive { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmailAddress { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual Abpuser CreatorUser { get; set; }
        public virtual Abpuser DeleterUser { get; set; }
        public virtual Abpuser LastModifierUser { get; set; }
        public virtual ICollection<Abppermission> Abppermissions { get; set; }
        public virtual ICollection<Abprole> AbproleCreatorUsers { get; set; }
        public virtual ICollection<Abprole> AbproleDeleterUsers { get; set; }
        public virtual ICollection<Abprole> AbproleLastModifierUsers { get; set; }
        public virtual ICollection<Abpsetting> Abpsettings { get; set; }
        public virtual ICollection<Abptenant> AbptenantCreatorUsers { get; set; }
        public virtual ICollection<Abptenant> AbptenantDeleterUsers { get; set; }
        public virtual ICollection<Abptenant> AbptenantLastModifierUsers { get; set; }
        public virtual ICollection<Abpuserclaim> Abpuserclaims { get; set; }
        public virtual ICollection<Abpuserlogin> Abpuserlogins { get; set; }
        public virtual ICollection<Abpuserrole> Abpuserroles { get; set; }
        public virtual ICollection<Abpusertoken> Abpusertokens { get; set; }
        public virtual ICollection<Abpuser> InverseCreatorUser { get; set; }
        public virtual ICollection<Abpuser> InverseDeleterUser { get; set; }
        public virtual ICollection<Abpuser> InverseLastModifierUser { get; set; }
    }
}

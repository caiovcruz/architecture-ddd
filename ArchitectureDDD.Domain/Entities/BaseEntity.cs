using System;

namespace ArchitectureDDD.Domain
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual bool Active { get; set; }
        public virtual string AuditUser { get; set; }
    }
}

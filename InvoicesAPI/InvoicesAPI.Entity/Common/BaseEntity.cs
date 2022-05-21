using System;

namespace InvoicesAPI.Entity.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual DateTime UpdatedTime { get; set; }
    }
}

using InvoicesAPI.Entity.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesAPI.Entity
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        [NotMapped]
        public override DateTime UpdatedTime { get => base.UpdatedTime; set => base.UpdatedTime = value; }
    }
}

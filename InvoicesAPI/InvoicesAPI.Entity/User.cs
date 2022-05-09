
using InvoicesAPI.Entity.Common;
using System;
using System.Collections.Generic;

namespace InvoicesAPI.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long TcNo { get; set; }
        public string Email { get; set; }
        public bool isHaveCar { get; set; }
        public string? CarPlate { get; set; }
    }
}

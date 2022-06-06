using InvoicesAPI.Entity.Common;

namespace InvoicesAPI.Entity
{
    public class House : BaseEntity
    {
        public int Block { get; set; }
        public string Type{ get; set; }
        public int AptNo { get; set; }
        public bool isEmpty { get; set; }
    }
}

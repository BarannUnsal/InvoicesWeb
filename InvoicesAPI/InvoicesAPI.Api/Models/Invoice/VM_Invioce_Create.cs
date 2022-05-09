namespace InvoicesAPI.Api.Models.Invoice
{
    public class VM_Invioce_Create
    {
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public bool isActive { get; set; }
    }
}

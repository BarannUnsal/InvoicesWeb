namespace InvoicesAPI.Api.Models.Invoice
{
    public class VM_Invoice_Update
    {
        public string Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public bool isActive { get; set; }
    }
}

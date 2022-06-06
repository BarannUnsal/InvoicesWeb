using MediatR;
using System.Collections.Generic;

namespace InvoicesAPI.Business.Features.Queries.InvoiceImageFile.GetInvoiceImage
{
    public class GetInvoiceImageQueryRequest : IRequest<List<GetInvoiceImageQueryResponse>>
    {
        public string Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.CreditCard.GetByIdCreditCard
{
    public class GetByIdCreditCardQueryRequest : IRequest<GetByIdCreditCardQueryResponse>
    {
        public string Id { get; set; }
    }
}

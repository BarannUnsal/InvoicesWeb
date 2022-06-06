using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.CreditCard.GetCreditCard
{
    public class GetCreditCardQueryResponse
    {
        public int TotalCount { get; set; }
        public object CreditCards { get; set; }
    }
}

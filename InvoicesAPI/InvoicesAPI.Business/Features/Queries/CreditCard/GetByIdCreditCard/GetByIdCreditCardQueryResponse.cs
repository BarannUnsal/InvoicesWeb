using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.CreditCard.GetByIdCreditCard
{
    public class GetByIdCreditCardQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityNumber { get; set; }
        public long CardNo { get; set; }
        public DateTime Expiration { get; set; }
    }
}

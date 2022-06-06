using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.CreditCard.RemoveCreditCard
{
    public class RemoveCreditCardCommandRequest : IRequest<RemoveCreditCardCommandResponse>
    {
        public string Id { get; set; }
    }
}

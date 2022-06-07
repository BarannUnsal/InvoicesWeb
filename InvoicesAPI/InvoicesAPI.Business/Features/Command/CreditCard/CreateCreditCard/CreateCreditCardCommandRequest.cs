using MediatR;
using System;

namespace InvoicesAPI.Business.Features.Command.CreditCard.CreateCreditCard
{
    public class CreateCreditCardCommandRequest : IRequest<CreateCreditCardCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SecurityNumber { get; set; }
        public long CardNo { get; set; }
        public DateTime Expiration { get; set; }
    }
}

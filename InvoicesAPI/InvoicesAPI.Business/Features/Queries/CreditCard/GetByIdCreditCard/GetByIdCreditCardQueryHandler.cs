using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.CreditCard.GetByIdCreditCard
{
    public class GetByIdCreditCardQueryHandler : IRequestHandler<GetByIdCreditCardQueryRequest, GetByIdCreditCardQueryResponse>
    {
        readonly ICreditCardReadRepository _creditCardReadRepostiory;
        public GetByIdCreditCardQueryHandler(ICreditCardReadRepository creditCardReadRepostiory)
        {
            _creditCardReadRepostiory = creditCardReadRepostiory;
        }
        public async Task<GetByIdCreditCardQueryResponse> Handle(GetByIdCreditCardQueryRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.CreditCard creditCard = await _creditCardReadRepostiory.GetByIdAsync(request.Id, false);
            return new()
            {
                CardNo = creditCard.CardNo,
                Description = creditCard.Description,
                Expiration = creditCard.Expiration,
                SecurityNumber = creditCard.SecurityNumber,
                Title = creditCard.Title
            };
        }
    }
}

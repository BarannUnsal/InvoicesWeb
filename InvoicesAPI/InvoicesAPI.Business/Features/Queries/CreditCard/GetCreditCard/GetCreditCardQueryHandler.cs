using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.CreditCard.GetCreditCard
{
    public class GetCreditCardQueryHandler : IRequestHandler<GetCreditCardQueryRequest, GetCreditCardQueryResponse>
    {
        readonly ICreditCardReadRepository _creditCardReadRepository;
        public GetCreditCardQueryHandler(ICreditCardReadRepository creditCardReadRepository)
        {
            _creditCardReadRepository = creditCardReadRepository;
        }
        public async Task<GetCreditCardQueryResponse> Handle(GetCreditCardQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _creditCardReadRepository.GetAll(false).Count();
            var creditCard = _creditCardReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Title,
                p.SecurityNumber,
                p.Expiration,
                p.Description,
                p.UpdatedTime,
                p.CreatedTime
            }).ToList();
            return new()
            {
                CreditCards = creditCard,
                TotalCount = totalCount
            };
        }
    }
}

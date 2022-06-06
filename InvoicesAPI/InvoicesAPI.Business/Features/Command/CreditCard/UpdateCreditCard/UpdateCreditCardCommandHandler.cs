using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.CreditCard.UpdateCreditCard
{
    public class UpdateCreditCardCommandHandler : IRequestHandler<UpdateCreditCardCommandRequest, UpdateCreditCardCommandResponse>
    {
        readonly ICreditCardReadRepository _creditCardReadRepository;
        readonly ICreditCardWriteRepository _creditCardWriteRepository;
        public UpdateCreditCardCommandHandler(ICreditCardReadRepository creditCardReadRepository, ICreditCardWriteRepository creditCardWriteRepository)
        {
            _creditCardReadRepository = creditCardReadRepository;
            _creditCardWriteRepository = creditCardWriteRepository;
        }
        public async Task<UpdateCreditCardCommandResponse> Handle(UpdateCreditCardCommandRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.CreditCard creditCard = await _creditCardReadRepository.GetByIdAsync(request.Id);
            creditCard.Description = request.Description;
            creditCard.Title = request.Title;
            creditCard.CardNo = request.CardNo;
            creditCard.SecurityNumber = request.SecurityNumber;
            creditCard.Expiration = request.Expiration;
            await _creditCardWriteRepository.SaveAsync();
            return new();
        }
    }
}

using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.CreditCard.CreateCreditCard
{
    public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommandRequest, CreateCreditCardCommandResponse>
    {
        readonly ICreditCardWriteRepository _creditCardWriteRepository;
        public CreateCreditCardCommandHandler(ICreditCardWriteRepository creditCardWriteRepository)
        {
            _creditCardWriteRepository = creditCardWriteRepository;
        }
        public async Task<CreateCreditCardCommandResponse> Handle(CreateCreditCardCommandRequest request, CancellationToken cancellationToken)
        {
            await _creditCardWriteRepository.AddAsync(new()
            {
                CardNo = request.CardNo,
                Description = request.Description,
                Title = request.Title,
                SecurityNumber = request.SecurityNumber,
                Expiration = request.Expiration
            });
            await _creditCardWriteRepository.SaveAsync();
            return new();
        }
    }
}

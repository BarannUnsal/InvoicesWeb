using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.CreditCard.RemoveCreditCard
{
    public class RemoveCreditCardCommandHandler : IRequestHandler<RemoveCreditCardCommandRequest, RemoveCreditCardCommandResponse>
    {
        readonly ICreditCardWriteRepository _creditCardWriteRepository;

        public RemoveCreditCardCommandHandler(ICreditCardWriteRepository creditCardWriteRepository)
        {
            _creditCardWriteRepository = creditCardWriteRepository;
        }

        public async Task<RemoveCreditCardCommandResponse> Handle(RemoveCreditCardCommandRequest request, CancellationToken cancellationToken)
        {
            await _creditCardWriteRepository.RemoveAsync(request.Id);
            await _creditCardWriteRepository.SaveAsync();
            return new();
        }
    }
}

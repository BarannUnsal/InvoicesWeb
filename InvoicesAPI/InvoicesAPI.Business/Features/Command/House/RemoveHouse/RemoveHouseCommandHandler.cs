using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.House.RemoveHouse
{
    public class RemoveHouseCommandHandler : IRequestHandler<RemoveHouseCommandRequest, RemoveHouseCommandResponse>
    {
        readonly IHouseWriteRepository _houseWriteRepository;
        public RemoveHouseCommandHandler(IHouseWriteRepository houseWriteRepository)
        {
            _houseWriteRepository = houseWriteRepository;
        }
        public async Task<RemoveHouseCommandResponse> Handle(RemoveHouseCommandRequest request, CancellationToken cancellationToken)
        {
            await _houseWriteRepository.RemoveAsync(request.Id);
            await _houseWriteRepository.SaveAsync();
            return new();
        }
    }
}

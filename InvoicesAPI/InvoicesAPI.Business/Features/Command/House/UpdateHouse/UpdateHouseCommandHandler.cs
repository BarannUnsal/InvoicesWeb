using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.House.UpdateHouse
{
    public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommandRequest, UpdateHouseCommandResponse>
    {
        readonly IHouseReadRepository _houseReadRepository;
        readonly IHouseWriteRepository _houseWriteRepository;
        public UpdateHouseCommandHandler(IHouseReadRepository houseReadRepository, IHouseWriteRepository houseWriteRepository)
        {
            _houseReadRepository = houseReadRepository;
            _houseWriteRepository = houseWriteRepository;
        }
        public async Task<UpdateHouseCommandResponse> Handle(UpdateHouseCommandRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.House house = await _houseReadRepository.GetByIdAsync(request.Id);
            house.Type = request.Type;
            house.Block = request.Block;
            house.AptNo = request.AptNo;
            house.isEmpty = request.isEmpty;
            await _houseWriteRepository.SaveAsync();
            return new();
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.House.RemoveHouse
{
    public class RemoveHouseCommandRequest : IRequest<RemoveHouseCommandResponse>
    {
        public string Id { get; set; } 
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.House.UpdateHouse
{
    public class UpdateHouseCommandRequest : IRequest<UpdateHouseCommandResponse>
    {
        public string Id { get; set; }
        public int Block { get; set; }
        public string Type { get; set; }
        public int AptNo { get; set; }
        public bool isEmpty { get; set; }
    }
}

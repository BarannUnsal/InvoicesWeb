using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.House.GetHouse
{
    public class GetHouseQueryResponse
    {
        public int TotalCount { get; set; } 
        public object Houses { get; set; }
    }
}

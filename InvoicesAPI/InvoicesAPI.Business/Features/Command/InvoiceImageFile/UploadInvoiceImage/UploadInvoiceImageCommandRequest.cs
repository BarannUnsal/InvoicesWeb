using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.InvoiceImageFile.UploadInvoiceImage
{
    public class UploadInvoiceImageCommandRequest : IRequest<UploadInvoiceImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files{ get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.InvoiceImageFile.GetInvoiceImage
{
    public class GetInvoiceImageQueryResponse
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public Guid Id { get; set; }
    }
}

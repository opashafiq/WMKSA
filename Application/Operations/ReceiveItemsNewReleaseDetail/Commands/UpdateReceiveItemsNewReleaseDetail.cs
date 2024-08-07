﻿using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ReceiveItemsNewReleaseDetail.Commands
{
    [AllArgsConstructor]
    public partial class UpdateReceiveItemsNewReleaseDetail : IRequest<Domain.Entities.ReceiveItemsNewReleaseDetail>
    {
        public long Id { get; set; }

        public long? ReceiveItemsNewReleaseId { get; set; }

        public int? Qty { get; set; }

        public long? ReceiveItemsNewId { get; set; }
    }
}

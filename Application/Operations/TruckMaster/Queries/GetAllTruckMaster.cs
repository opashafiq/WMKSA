﻿using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.TruckMaster.Queries
{
    public record GetAllTruckMaster : IRequest<ICollection<TruckMasterDto>>
    {
        public int Id { get; set; }
        public GetAllTruckMaster()
        {
        }

    };
}

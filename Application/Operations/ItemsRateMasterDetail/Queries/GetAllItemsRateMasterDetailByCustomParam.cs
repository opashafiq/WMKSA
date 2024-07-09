using Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Queries
{
    public record GetAllItemsRateMasterDetailByCustomParam : IRequest<ICollection<ItemsRateMasterDetailDto>>
    {
        public int Id { get; set; }
        public long _customerMasterId { get; set; }
        public long _recItemMasterId { get; set; }
        public long _unitMasterId { get; set; }
        public GetAllItemsRateMasterDetailByCustomParam(long CustomerMasterId,long RecItemMasterId,long UnitMasterId)
        {
            _customerMasterId= CustomerMasterId;
            _recItemMasterId= RecItemMasterId;
            _unitMasterId= UnitMasterId;
        }

    };
}

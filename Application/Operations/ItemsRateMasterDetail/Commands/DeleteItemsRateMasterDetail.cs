using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMasterDetails.Commands
{
    public class DeleteItemsRateMasterDetail : IRequest<Domain.Entities.ItemsRateMasterDetail>
    {
        public int Id { get; set; }

        public DeleteItemsRateMasterDetail(int id)
        {
            Id = id;
        }
    }
}

using Lombok.NET;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.Commands
{
    [AllArgsConstructor]
    public partial class CreateItemService : IRequest<Domain.Entities.ItemService>
    {
        public string? ItemsService { get; set; }

        public bool? IndividualUnit { get; set; }

    }
}

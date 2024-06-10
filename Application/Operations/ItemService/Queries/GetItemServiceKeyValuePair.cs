using Application.Common.Dtos;
using MediatR;
using System.Threading.Tasks;

namespace Application.Operations.ItemService.Queries
{
    public record GetItemServiceKeyValuePair : IRequest<ICollection<ItemServiceKeyValueDto>>
    {
        public int Id { get; set; }
        public GetItemServiceKeyValuePair()
        {
        }

    };
}
using Application.Common.Dtos;
using MediatR;
using System.Threading.Tasks;

namespace Application.Operations.ItemsRateMaster.Queries
{
    public record GetItemsRateMasterKeyValuePair : IRequest<ICollection<ItemsRateMasterKeyValueDto>>
    {
        public int Id { get; set; }
        public GetItemsRateMasterKeyValuePair()
        {
        }

    };
}
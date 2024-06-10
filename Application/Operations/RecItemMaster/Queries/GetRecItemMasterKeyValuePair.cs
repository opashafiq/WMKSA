using Application.Common.Dtos;
using MediatR;
using System.Threading.Tasks;

namespace Application.Operations.RecItemMaster.Queries
{
    public record GetRecItemMasterKeyValuePair : IRequest<ICollection<RecItemMasterKeyValueDto>>
    {
        public int Id { get; set; }
        public GetRecItemMasterKeyValuePair()
        {
        }

    };
}
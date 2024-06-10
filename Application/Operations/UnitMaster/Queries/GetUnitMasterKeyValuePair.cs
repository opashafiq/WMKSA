using Application.Common.Dtos;
using MediatR;
using System.Threading.Tasks;

namespace Application.Operations.UnitMaster.Queries
{
    public record GetUnitMasterKeyValuePair : IRequest<ICollection<UnitMasterKeyValueDto>>
    {
        public int Id { get; set; }
        public GetUnitMasterKeyValuePair()
        {
        }

    };
}
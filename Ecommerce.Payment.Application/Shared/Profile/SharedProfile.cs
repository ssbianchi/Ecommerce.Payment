using Ecommerce.Payment.Application.Shared.Dto;
using Ecommerce.Payment.Domain.Entity.Readonly.Dapper;

namespace Ecommerce.Payment.Application.Shared.Profile
{
    public class SharedProfile : AutoMapper.Profile
    {
        public SharedProfile()
        {
            CreateMap<DapperIdName, IdNameDto>();
        }
    }
}

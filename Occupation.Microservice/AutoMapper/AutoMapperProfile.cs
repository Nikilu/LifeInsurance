using AutoMapper;
using OccupationMicroservice.Model;

namespace OccupationMicroservice.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Persistence.Occupation, Occupation>();
        }
    }
}

using AutoMapper;
using OccupationMicroservice.Common;
using OccupationMicroservice.Interface; 
using System.Collections.Generic;
using System.Linq;

namespace OccupationMicroservice.Service
{
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationContext _dbContext;
        private readonly IMapper _mapper;

        public OccupationService(IOccupationContext dbContext, IMapper mapper)
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<Model.Occupation> GetOccupations()
        { 
            var occupationList = _mapper.Map<List<Model.Occupation>>(_dbContext.Occupations.ToList());
            return occupationList;
        }

        public decimal GetOccupationRatingFactor(int id)
        {
            var occupationRating = _dbContext.OccupationRatings.Where(x => x.OccupationRatingId == id).FirstOrDefault();
            if (occupationRating != null)
                return occupationRating.Factor;
            else
                return Constants.DEFAULT_RATING_FACTOR;
        } 
    }
}

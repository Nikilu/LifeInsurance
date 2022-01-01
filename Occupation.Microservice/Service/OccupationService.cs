using AutoMapper;
using Microsoft.EntityFrameworkCore; 
using OccupationMicroservice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<List<Model.Occupation>> GetOccupations()
        {
            var occupationList = _mapper.Map<List<Model.Occupation>>(await _dbContext.Occupations.ToListAsync());

            return occupationList;
        }

        public async Task<decimal> GetOccupationRatingFactor(int id)
        {
            var occupationRating = await _dbContext.OccupationRatings.Where(x => x.OccupationRatingId == id).FirstOrDefaultAsync();
            if (occupationRating != null)
                return occupationRating.Factor;
            else
                throw new InvalidOperationException(nameof(GetOccupationRatingFactor));
        }
    }
}

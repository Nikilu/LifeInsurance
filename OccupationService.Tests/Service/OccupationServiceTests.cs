using AutoFixture;
using AutoMapper;
using OccupationMicroservice.AutoMapper;
using OccupationMicroservice.DBContext;
using OccupationMicroservice.Persistence;
using OccupationMicroservice.Service;
using OccupationMicroservice.Tests.DbContext;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace OccupationMicroservice.Tests.Service
{
    public class OccupationServiceTests
    {

        private static readonly Fixture Fixture = new Fixture();
        private static readonly IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()))
                                                                                    .CreateMapper();
        private readonly OccupationContext _db;
        private readonly OccupationService _occupationService;

        public OccupationServiceTests()
        {
            _db = DBContextFactory.CreateDB<OccupationServiceTests>().Result;
            _occupationService = new OccupationService(_db, _mapper);
        }

        [Fact]
        public async void WhenOccupationIsNotFound_ShouldThrowInvalidException()
        {
            //Arrange
            var occupationId = 899;
            var occupationRatingList = GetOccupationRatings();
            _db.OccupationRatings.AddRange(occupationRatingList);

            //Act
            //Assert
            await _occupationService.GetOccupationRatingFactor(occupationId).ShouldThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async void WhenOccupationIsFound_ShouldReturnRatingFactor()
        {
            //Arrange 
            var ratingFactor = 1.00m;
            var occupationRatingList = GetOccupationRatings();
            _db.OccupationRatings.AddRange(occupationRatingList);
            await _db.SaveChangesAsync();


            //Act
            var result = await _occupationService.GetOccupationRatingFactor(occupationRatingList[0].OccupationRatingId);

            //Assert
            result.ShouldBe(ratingFactor);
        }

        private static IList<OccupationRating> GetOccupationRatings()
        {
            var occupationList = new List<OccupationRating>();
            for (var i = 1; i <= 5; i++)
            {
                var occupationRating = Fixture.Build<OccupationRating>()
                    .With(p => p.OccupationRatingId, i)
                    .With(p => p.OccupationRatingName, i.ToString())
                    .With(p => p.Factor, 1)
                    .Create();
                occupationList.Add(occupationRating);
            }

            return occupationList;
        }
    }
}

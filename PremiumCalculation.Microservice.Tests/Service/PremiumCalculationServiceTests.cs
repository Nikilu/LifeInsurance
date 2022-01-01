using AutoFixture;
using Moq;
using OccupationMicroservice.Persistence;
using PremiumCalculationMicroservice.Interface;
using PremiumCalculationMicroservice.Models;
using PremiumCalculationMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace PremiumCalculation.Microservice.Tests.Service
{
    public class PremiumCalculationServiceTests
    {
        private static readonly Fixture Fixture = new Fixture();
        private readonly Mock<IOccupationService> _mockOccupationService = new Mock<IOccupationService>();

        public PremiumCalculationServiceTests()
        {
        }


        [Fact]
        public async void WhenAgeIsLessThanMinimum_ShouldThrowInvalidException()
        {
            // Arrange
            var input = Fixture.Build<PremiumByOccupationInput>().With(p => p.DateOfBirth, DateTime.Now.Date).Create();

            var premiumCalculationService = new PremiumCalculationService(_mockOccupationService.Object);

            // Act
            // Assert
            await premiumCalculationService.CalculateYearlyDeathPremium(input).ShouldThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async void WhenOccupationIdIsInvalid_ShouldThrowInvalidException()
        {
            // Arrange
            var occupationRatings = GetOccupationRatings();
            const int fakeOCcupationId = -1;

            var input = Fixture.Build<PremiumByOccupationInput>()
                                .With(p => p.DateOfBirth, DateTime.Now.Date.AddYears(-25))
                                .With(p => p.OccupationId, fakeOCcupationId).Create();

            _mockOccupationService.Setup(f => f.GetRatingFactor(input.OccupationId))
                                  .Returns(Task.FromResult(0.0m));

            var premiumCalculationService = new PremiumCalculationService(_mockOccupationService.Object);

            // Act
            // Assert
            await premiumCalculationService.CalculateYearlyDeathPremium(input).ShouldThrowAsync<InvalidOperationException>();

        }

        [Fact]
        public async void WhenOccupationIdIsValid_ShouldReturnDeathPremium()
        {
            //Arrange
            var occupationRatings = GetOccupationRatings();

            var input = Fixture.Build<PremiumByOccupationInput>()
                                .With(p => p.DateOfBirth, DateTime.Now.Date.AddYears(-25))
                                .With(p => p.OccupationId, occupationRatings[0].OccupationRatingId)
                                .With(p => p.CoverAmount, 100.00m).Create();

            _mockOccupationService.Setup(f => f.GetRatingFactor(input.OccupationId))
                                  .Returns(Task.FromResult(1.0m));

            var premiumCalculationService = new PremiumCalculationService(_mockOccupationService.Object);

            // Act
            var result = await premiumCalculationService.CalculateYearlyDeathPremium(input);

            // Assert
            result.ShouldBe(30.00m);
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

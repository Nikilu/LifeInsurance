namespace OccupationMicroservice.Persistence
{
    public class OccupationRating
    {
        public int OccupationRatingId {get; set;} 

        public string OccupationRatingName { get; set; }

        public decimal Factor { get; set; }
    }
}

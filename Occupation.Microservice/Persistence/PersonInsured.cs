using System; 

namespace OccupationMicroservice.Persistence
{
    public class PersonInsured
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int OccupationId { get; set; }

        public decimal SumInsured { get; set; }

        public DateTime CreateDatetime { get; set; }
    }
}

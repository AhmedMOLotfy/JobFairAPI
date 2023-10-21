using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using JobFairAPI.Extensions;

namespace JobFairAPI.Entities
{
    [Table("CandidatesDetails")]
    public class CandidatesDetails
    {
        public int Id {get; set;}
        public string JobTitle { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone {get; set;}
        public int CandidatesId { get; set; }
        public Candidates candidates {get; set;} = null!;
        
        public int GetAge(){
            return DateOfBirth.CalculateAge();
        }

    }
}
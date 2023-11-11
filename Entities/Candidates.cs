using JobFairAPI.Extensions;

namespace JobFairAPI.Entities
{
    public class Candidates
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public string JobTitle { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone {get; set;}
        public string PhotoUrl {get; set;}
        public string Cv {get; set;}
        public int? GetAge(){
            return DateOfBirth.HasValue? DateOfBirth?.CalculateAge() : null;
        }

    }
}
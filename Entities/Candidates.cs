namespace JobFairAPI.Entities
{
    public class Candidates
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}

        // reference to details table
        public CandidatesDetails details{get; set;}
    }
}
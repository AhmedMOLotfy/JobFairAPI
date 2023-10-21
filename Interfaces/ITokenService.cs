using JobFairAPI.Entities;

namespace JobFairAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Candidates candidate);
    }
}
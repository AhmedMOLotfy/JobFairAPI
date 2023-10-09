using JobFairAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){

        }

        public DbSet<CandidatesEntity> Candidates {get; set;}

    }
}
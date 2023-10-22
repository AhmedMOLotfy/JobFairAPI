using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFairAPI.Entities;

namespace JobFairAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(Candidates candidates);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Candidates>> GetUsersAsync();

        Task<Candidates> GetUserByIDAsync(int id);

        Task<Candidates> GetUserByEmailAsync(string email);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFairAPI.Entities;
using JobFairAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context){
            _context = context;
        }

        public async Task<IEnumerable<Candidates>> GetUsersAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidates> GetUserByEmailAsync(string email)
        {
            return await _context.Candidates.SingleOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Candidates> GetUserByIDAsync(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Candidates candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
        }
    }
}
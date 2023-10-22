using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobFairAPI.DTOs;
using JobFairAPI.Entities;
using JobFairAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper){
            _mapper = mapper;
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

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Candidates.ProjectTo<MemberDto>
                        (_mapper.ConfigurationProvider).ToListAsync(); 
        }

        public async Task<MemberDto> GetCandidateAsync(string email)
        {
            return await _context.Candidates.Where(x => x.Email == email).
                    ProjectTo<MemberDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }
    }
}
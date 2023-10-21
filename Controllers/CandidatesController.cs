using JobFairAPI.Data;
using JobFairAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Controllers
{
    [Authorize]
    public class CandidatesController : BaseApiController
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidates()
        {
            var users = await _context.Candidates.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidates>> GetCandidate(int id)
        {
            var user = await _context.Candidates.FindAsync(id);
            return user;
        }

    }



}
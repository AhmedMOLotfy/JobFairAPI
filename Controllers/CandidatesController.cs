using JobFairAPI.Data;
using JobFairAPI.Entities;
using JobFairAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Controllers
{
    [Authorize]
    public class CandidatesController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        public CandidatesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidates()
        {
            return Ok(await _userRepository.GetUsersAsync());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidates>> GetCandidateById(int id)
        {
            return await _userRepository.GetUserByIDAsync(id);
        }

        // [HttpGet("{email}")]
        // public async Task<ActionResult<Candidates>> GetCandidatesByEmail(string ){

        // }

    }



}
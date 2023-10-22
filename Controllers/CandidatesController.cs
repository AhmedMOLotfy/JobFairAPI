using AutoMapper;
using JobFairAPI.Data;
using JobFairAPI.DTOs;
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
        private readonly IMapper _mapper;

        public CandidatesController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetCandidates()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
            
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<MemberDto>> GetCandidateByEmail(string email)
        {
            return await _userRepository.GetCandidateAsync(email);
        }

    }



}
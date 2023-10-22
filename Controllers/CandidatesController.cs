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
            var users = await _userRepository.GetUsersAsync();

            // return users in the form of mapper applyed using MemberDto
            var userToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

            return Ok(userToReturn);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetCandidateById(int id)
        {
            var user = await _userRepository.GetUserByIDAsync(id);
            return _mapper.Map<MemberDto>(user);
        }

        // [HttpGet("{email}")]
        // public async Task<ActionResult<Candidates>> GetCandidatesByEmail(string ){

        // }

    }



}
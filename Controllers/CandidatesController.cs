using AutoMapper;
using JobFairAPI.Data;
using JobFairAPI.DTOs;
using JobFairAPI.Entities;
using JobFairAPI.Extensions;
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
        private readonly IPhotoService _photoService;

        public CandidatesController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
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

        [HttpPost("add-photo")]
        public async Task<ActionResult> AddPhoto(IFormFile file){
            // get the user from Db By calculating email from token
            var user = await _userRepository.GetUserByEmailAsync(User.GetUserEmail());

            // if we do not find user 
            if(user == null) return NotFound();

            // adding photo to the server (Cloudinary)
            var result = await _photoService.AddPhotoAsync(file);

            // in case of error
            if(result.Error != null) return BadRequest(result.Error.Message);

            int startIndex = user.PhotoUrl.LastIndexOf('/');
            string imageFile = user.PhotoUrl.Substring(startIndex + 1);
            string fileName = imageFile.Substring(0,imageFile.LastIndexOf("."));

            // user and their associated photos
            user.PhotoUrl = result.SecureUrl.AbsoluteUri;
            // return photoDto mapped from (photo)
            if(await _userRepository.SaveAllAsync()){
                return Ok(fileName);
            }

            return BadRequest("Something wrong with adding photo");
        }
    }



}
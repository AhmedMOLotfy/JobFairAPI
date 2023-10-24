using System.Security.Cryptography;
using System.Text;
using JobFairAPI.Data;
using JobFairAPI.DTOs;
using JobFairAPI.Entities;
using JobFairAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobFairAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("Email is taken");

            using var hmac = new HMACSHA512();

            var user = new Candidates
            {
                UserName = registerDto.Username.ToLower(),
                Email = registerDto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Candidates.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Email = registerDto.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login
                    (LoginDto loginDto) // recieve email, password
        {
            // find user which associated with email which is provided
            var user = await _context.Candidates.SingleOrDefaultAsync(x =>
                x.Email == loginDto.Email);
            
            // if email is not provided , give unatherized
            if (user == null) return Unauthorized("invalid email");

            // encrypt the password to compare with stored one
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                // if it is not correct, give unatherized
                if (computedHash[i] != user.PasswordHash[i]) {
                    return Unauthorized("invalid password");
                }
            }

            // return user's data {email, Username , secured token}
            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string email)
        {
            return await _context.Candidates.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
using AutoMapper;
using JobFairAPI.DTOs;
using JobFairAPI.Entities;

namespace JobFairAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){
            CreateMap<Candidates,MemberDto>();
        }
    }
}
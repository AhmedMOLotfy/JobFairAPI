using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairAPI.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone {get; set;}
        public string PhotoUrl {get; set;}
        public string Cv{get; set;}
    }
}
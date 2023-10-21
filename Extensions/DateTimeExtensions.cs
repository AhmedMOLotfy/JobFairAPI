using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob){
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dob.Year;
            // perfect way to calculate age
            if(dob > today.AddYears(-age)) age--;
            
            return age;
        }
    }
}
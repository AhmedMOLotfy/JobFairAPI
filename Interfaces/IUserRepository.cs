using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFairAPI.Entities;

namespace JobFairAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(Candidates candidates);
        
    }
}
using PeopleEssence.BusinessLayer.Models.RequestBody;
using PeopleEssence.BusinessLayer.Models.ResponseBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Interface
{
    public interface IRepository
    {
      
       Task<APIResponse> ApplyCandidateAsync(CandidatesVM candidate);
       Task<APIResponse> GetCandidateByEmailAsync(string email);
       Task<APIResponse> GetCandidateByIdAsync(int Id);
 




    }
}

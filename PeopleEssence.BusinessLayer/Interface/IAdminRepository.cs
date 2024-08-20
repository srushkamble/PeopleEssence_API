using PeopleEssence.BusinessLayer.Models.ResponseBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Interface
{
    public interface IAdminRepository
    {
        Task<APIResponse> IsValidAdminAsync(string AdminId, string Password);

        Task<CandidateAPIResponse> GetAllCandidatesAsync();

    }
}

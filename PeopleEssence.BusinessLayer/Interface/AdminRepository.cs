using Microsoft.EntityFrameworkCore;
using PeopleEssence.BusinessLayer.Models.RequestBody;
using PeopleEssence.BusinessLayer.Models.ResponseBody;
using PeopleEssence.DataContext.Data;
using PeopleEssence.DataContext.Entities;
using PeopleEssence.DataContext.Entities.TableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Interface
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PeopleEssenceDbContext _adminRepository;
        private readonly HttpClient _httpClient;

        public AdminRepository(PeopleEssenceDbContext context)
        {
            _adminRepository = context;
            _httpClient = new HttpClient();
        }

        public async Task<APIResponse> IsValidAdminAsync(string AdminId, string Password)
        {
            APIResponse response = new APIResponse();

            using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
            {
                try
                {
                 
                    var admin = await db.Admins.FirstOrDefaultAsync(a => a.AdminId == AdminId && a .Password == Password);
                    if(admin != null)
                    {
                        response.Code = 200;
                        response.Status = "success";
                        response.Message = "Authentication success.";

                        return response;
                    }
                    else
                    {
                        response.Status = "error";
                        response.Message = "Failed.";
                    }
                  
                }
                catch (Exception ex)
                {
                    response.Status = "error";
                    response.Message = ex.Message;
                    return response;
                }
                return response;
            }
        }


        //public async Task<CandidateAPIResponse> GetAllCandidatesAsync()
        //{
        //    CandidateAPIResponse result = new CandidateAPIResponse();
        //    using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
        //    {
        //        var data = await db.Candidates.ToListAsync();

        //        if (data != null && data.Any())
        //        {
        //            result.Code = 200;
        //            result.Status = "success";
        //            result.Message = "Candidate Details";
        //            result.Data = data;

        //        }
        //        else
        //        {
        //            result.Code = 404;
        //            result.Status = "error";
        //            result.Message = "No candidates found.";
        //        }
        //    }
        //    return result;
        //}

        public async Task<CandidateAPIResponse> GetAllCandidatesAsync()
        {
            CandidateAPIResponse result = new CandidateAPIResponse();
            using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
            {
                var candidates = await db.Candidates.ToListAsync();
                var candidateDetails = await db.CandidatesDetails.ToListAsync();

                var combinedData = Ca(candidates, candidateDetails);

                var combinedData = candidates.Select(candidate =>
                {
                    var detail = candidateDetails.FirstOrDefault(cd => cd.CandidateId == candidate.CandidateId);
                    CandidatesVM candidatesVM = new CandidatesVM
                    {
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Education = candidate.Ed
                    };

                    
                }).ToList();

                if (combinedData.Any())
                {

                    result.Code = 200;
                    result.Status = "success";
                    result.Message = " Candidate Details";
                    result.Data = combinedData;
                    
                }
                else
                {
                    result.Code = 404;
                    result.Status = "error";
                    result.Message = "No  candidates found.";
                }
            }
            return result;
        }

       
    }
}

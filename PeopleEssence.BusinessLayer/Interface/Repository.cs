using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PeopleEssence.BusinessLayer.Models.RequestBody;
using PeopleEssence.BusinessLayer.Models.ResponseBody;
using PeopleEssence.DataContext.Data;
using PeopleEssence.DataContext.Entities;
using PeopleEssence.DataContext.Entities.TableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Interface
{
    public class Repository: IRepository
    {
        private readonly PeopleEssenceDbContext _context;
        private readonly HttpClient _httpClient;

        public Repository(PeopleEssenceDbContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        

        //Candidate
        public async Task<APIResponse> ApplyCandidateAsync(CandidatesVM candidate)
        {
            APIResponse result = new APIResponse();
            try
            {
                using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
                {
                    var checkId = await db.Candidates.Where(c => c.Email== candidate.Email).FirstOrDefaultAsync();
                    if(checkId != null)
                    {
                        result.Message = "Already Exist.";
                    }
                    else
                    {
                        Candidate newCandidate = new Candidate()
                        {
                            FirstName = candidate.FirstName,
                            LastName = candidate.LastName,
                            Email = candidate.Email,
                            PhoneNumber = candidate.PhoneNumber,
                            Gender = candidate.Gender,
                            Address = candidate.Address,
                            Resumefile = candidate.Resumefile,
                            AppliedPosition = candidate.AppliedPosition,
                            Skills = candidate.Skills,
                            CurrentLocation = candidate.CurrentLocation,
                            PreferedLocation = candidate.PreferedLocation,
                            CurrentCtc = candidate.CurrentCtc,
                            ExpectedCtc = candidate.ExpectedCtc,
                            References = candidate.References,
                            ReferencesEmpId = candidate.ReferencesEmpId,
                            LinkedInLink = candidate.LinkedInLink,
                            RegistrationDate = candidate.RegistrationDate,
                            Status = "Applied",
                        };
                        db.Candidates.Add(newCandidate);
                        var cnt = await db.SaveChangesAsync();
                        if (cnt > 0) 
                        {

                            var newCandidateId = newCandidate.CandidateId;
                            CandidatesDetail newCandidateDetail = new CandidatesDetail()
                            {
                                CandidateId = newCandidateId, 
                                PreviousEmp = candidate.PreviousEmp,
                                FromDate = candidate.FromDate,
                                ToDate = candidate.ToDate,
                                Education = candidate.Education,
                                EduFromDate = candidate.EduFromDate,
                                EduToDate = candidate.EduToDate,
                            };
                            db.CandidatesDetails.Add(newCandidateDetail);
                            var detailCnt = await db.SaveChangesAsync();

                            if (detailCnt > 0)
                            {
                                result.Code = 200;
                                result.Status = "Success";
                                result.Message = "Candidate Applied.";
                            }
                        }
                        else
                        {
                            result.Code = 500;
                            result.Status = "Failed";
                            result.Message = "error.";

                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                    result.Message = ex.Message;
            }
            return result;
        }

        public async Task<APIResponse> GetCandidateByEmailAsync(string email)
        {

            using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
            {
                APIResponse response = new APIResponse();
                try
                {
                    var info = await db.Candidates.Where( i => i.Email == email ).ToListAsync();
                    if(info.Count != 0)
                    {
                        response.Status = "success";
                      
                    }
                    else
                    {
                        response.Status = "failed";
                       
                    }
                    return response;

                }
                catch (Exception ex) 
                {
                    response.Status = "error";
                    response.Message = ex.Message;
                    return response;
                }

            }


        }

        public async Task<APIResponse> GetCandidateByIdAsync(int Id)
        {

            using (PeopleEssenceTestEntities db = new PeopleEssenceTestEntities())
            {
                APIResponse response = new APIResponse();
                try
                {
                    var info = await db.Candidates.Where(i => i.CandidateId == Id).ToListAsync();
                    if (info.Count != 0)
                    {
                        response.Status = "success";
                      
                    }
                    else
                    {
                        response.Status = "failed";
                        
                    }
                    return response;

                }
                catch (Exception ex)
                {
                    response.Status = "error";
                    response.Message = ex.Message;
                    return response;
                }

            }


        }

      




    }





}

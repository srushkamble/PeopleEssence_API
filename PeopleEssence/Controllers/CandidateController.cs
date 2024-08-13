using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using PeopleEssence.BusinessLayer.Interface;
using PeopleEssence.BusinessLayer.Models.RequestBody;
using PeopleEssence.BusinessLayer.Models.ResponseBody;
using PeopleEssence.DataContext.Entities.TableEntities;

namespace PeopleEssence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CandidateController : ControllerBase
    {
        private readonly IRepository objRep;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(IRepository repository, IConfiguration configuration, ILogger<CandidateController> logger)
        {
            _configuration = configuration;
            objRep = repository;
            _logger = logger;
            _logger.LogInformation("\n\nCandidateController Logs : \n");
        }

        //Candidate
        [HttpPost]
        [Route("Registration")]
        public async Task<APIResponse> AddCandidate([FromBody] ApplyCandidates candidates)
        {
            APIResponse result = new APIResponse();
            result = await objRep.ApplyCandidateAsync(candidates);
            if (result.Code == 200 && result.Status == "success")
            {
                return result;
            }
            else
            {
                return result;
            }
        }

        [HttpGet]
        [Route("GetCandidate")]
        public async Task<APIResponse> CandidateInformation(string email)
        {
            APIResponse result = new APIResponse();
            result = await objRep.GetCandidateByEmailAsync(email);
            if (result.Code == 200)
            {
                return result;
            }
            else
            {
                return result;
            }

        }


        [HttpGet]
        [Route("GetCandidatebyId")]
        public async Task<APIResponse> CandidateInformationbyId(int Id)
        {
            APIResponse result = new APIResponse();
            result = await objRep.GetCandidateByIdAsync(Id);
            if (result.Code == 200)
            {
                return result;
            }
            else
            {
                return result;
            }

        }

        //CandidateDetail

       
        


    }
}

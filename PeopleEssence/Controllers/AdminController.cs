using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PeopleEssence.BusinessLayer.Interface;
using PeopleEssence.BusinessLayer.Models.ResponseBody;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PeopleEssence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository objRep;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminRepository repository, IConfiguration configuration, ILogger<AdminController> logger)
        {
            _configuration = configuration;
            objRep = repository;
            _logger = logger;
            _logger.LogInformation("\n\nAdminController Logs : \n");
        }

        [HttpPost]
        [Route("ValidateAdmin")]
        public async Task<APIResponse> Login(string AdminId, string Password)
        {
            APIResponse response = new APIResponse();
            response = await objRep.IsValidAdminAsync(AdminId, Password);
            if (response.Code == 200 && response.Status == "success")
            {
                return response;
            }
            else
            {
                return response;
            }
        }

        [HttpGet]
        [Route("GetCandidateList")]
        public async Task<CandidateAPIResponse> GetCandidates()
        {
            CandidateAPIResponse response = new CandidateAPIResponse();
            response = await objRep.GetAllCandidatesAsync();
            if(response.Code == 200 && response.Status=="success")
            {
                return response;
            }
            else
            {
                return response;
            }
        }

        
    }

}


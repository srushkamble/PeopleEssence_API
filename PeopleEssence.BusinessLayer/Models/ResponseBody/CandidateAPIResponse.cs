using PeopleEssence.DataContext.Entities.TableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Models.ResponseBody
{
    public class CandidateAPIResponse
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        //public string? Data { get; set; }
        public List<Candidate>? Data { get; set; }

        
    }
}

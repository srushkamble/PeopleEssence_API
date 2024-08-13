using PeopleEssence.DataContext.Entities.TableEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Models.RequestBody
{
    public class CandidateDetailsVM
    {
        public int CandidateDetailsId { get; set; }
        public int CandidateId { get; set; }
        public string? PreviousEmp { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Education { get; set; }
        public DateTime? EduFromDate { get; set; }
        public DateTime? EduToDate { get; set; }

        [ForeignKey(nameof(CandidateId))]
        public virtual Candidate? Candidate { get; set; }
    }
}

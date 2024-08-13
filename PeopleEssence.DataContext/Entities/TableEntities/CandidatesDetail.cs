using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleEssence.DataContext.Entities.TableEntities
{
    public partial class CandidatesDetail
    {
        [Key]
        public int CandidateDetailsId { get; set; }
        [Column("CandidateID")]
        public int? CandidateId { get; set; }
        [StringLength(100)]
        public string? PreviousEmp { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        [StringLength(255)]
        public string? Education { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EduFromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EduToDate { get; set; }

        [ForeignKey(nameof(CandidateId))]
        [InverseProperty("CandidatesDetails")]
        public virtual Candidate? Candidate { get; set; }
    }
}

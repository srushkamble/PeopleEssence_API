using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Models.ResponseBody
{
    public class APIResponse
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }


    }

   
}

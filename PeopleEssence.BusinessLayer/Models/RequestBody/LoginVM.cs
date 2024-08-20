using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.BusinessLayer.Models.RequestBody
{
    public class LoginVM
    {
        public string? AdminId { get; set; } 

        public string? Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleEssence.DataContext.Entities.TableEntities
{
    public partial class Admin
    {
        [Key]
        [StringLength(50)]
        public string AdminId { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;
    }
}

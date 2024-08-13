using Microsoft.EntityFrameworkCore;
using PeopleEssence.DataContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleEssence.DataContext.Entities
{
    public class PeopleEssenceTestEntities: PeopleEssenceDbContext
    {
        public PeopleEssenceTestEntities()
        {

        }
        public PeopleEssenceTestEntities(DbContextOptions<PeopleEssenceDbContext> options)
            : base(options)
        {

        }

    }
}

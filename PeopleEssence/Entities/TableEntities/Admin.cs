using System.ComponentModel.DataAnnotations;

namespace PeopleEssence.Entities.TableEntities
{
    public class Admin
    {
        [StringLength(50)]
        public string AdminId { get; set; } = null!;
        [StringLength(50)]
        public string Password { get; set; } = null!;
    }
}

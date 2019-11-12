using System.ComponentModel.DataAnnotations.Schema;

namespace SectorApp.DataAccess.Models
{
    public class EntityBase
    {
        public int Id { get; set; }

        [NotMapped]
        public bool IsNew => Id == 0;
    }
}
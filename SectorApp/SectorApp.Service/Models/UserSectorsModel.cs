using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SectorApp.DataAccess.Models;

namespace SectorApp.Service.Models
{
    public class UserSectorsModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Sector> Sectors { get; set; }
        [Required]
        public bool TermsIsAccepted { get; set; }
        public bool IsNew => Id == 0;
    }
}
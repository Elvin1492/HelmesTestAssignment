using System.Collections.Generic;
using SectorApp.DataAccess.Models;

namespace SectorApp.Service.Models
{
    public class UserSectorsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sector> Sectors { get; set; }
        public bool TermsIsAccepted { get; set; }
        public bool IsNew => Id == 0;
    }
}
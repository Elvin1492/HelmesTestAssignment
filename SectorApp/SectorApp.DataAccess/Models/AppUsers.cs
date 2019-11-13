using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class AppUser:EntityBase
    {
        public AppUser()
        {
            UsersSectors = new HashSet<UsersSector>();
        }

        public string Name { get; set; }
        public bool TermsIsAccepted { get; set; }

        public virtual ICollection<UsersSector> UsersSectors { get; set; }
    }
}

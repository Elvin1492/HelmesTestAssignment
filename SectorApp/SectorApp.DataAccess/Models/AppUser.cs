using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class AppUser: EntityBase
    {
        public AppUser()
        {
            UsersSectors = new HashSet<UsersSectors>();
        }

        public string Name { get; set; }

        public virtual ICollection<UsersSectors> UsersSectors { get; set; }
    }
}

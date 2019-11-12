using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class AppUsers
    {
        public AppUsers()
        {
            UsersSectors = new HashSet<UsersSectors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersSectors> UsersSectors { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class UsersSectors : EntityBase
    {
        public int UserId { get; set; }
        public int SectorId { get; set; }

        public virtual Sector IdNavigation { get; set; }
        public virtual AppUser User { get; set; }
    }
}

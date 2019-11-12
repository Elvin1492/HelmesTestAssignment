using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class UsersSectors
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SectorId { get; set; }

        public virtual Sectors IdNavigation { get; set; }
        public virtual AppUsers User { get; set; }
    }
}

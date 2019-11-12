using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class Sector : EntityBase
    {
        public Sector()
        {
            InverseParent = new HashSet<Sector>();
        }

        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Sector Parent { get; set; }
        public virtual UsersSectors UsersSectors { get; set; }
        public virtual ICollection<Sector> InverseParent { get; set; }
    }
}

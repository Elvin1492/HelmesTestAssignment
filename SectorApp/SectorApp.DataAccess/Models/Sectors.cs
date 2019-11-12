using System;
using System.Collections.Generic;

namespace SectorApp.DataAccess.Models
{
    public partial class Sectors
    {
        public Sectors()
        {
            InverseParent = new HashSet<Sectors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Sectors Parent { get; set; }
        public virtual UsersSectors UsersSectors { get; set; }
        public virtual ICollection<Sectors> InverseParent { get; set; }
    }
}

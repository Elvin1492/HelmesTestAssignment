namespace SectorApp.DataAccess.Models
{
    public class Sector:EntityBase
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Sector Parent { get; set; }
        public virtual UsersSector UsersSectors { get; set; }
    }
}

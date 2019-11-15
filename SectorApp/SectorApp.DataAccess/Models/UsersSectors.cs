namespace SectorApp.DataAccess.Models
{
    public class UsersSector:EntityBase
    {
        public int UserId { get; set; }
        public int SectorId { get; set; }

        public virtual Sector IdNavigation { get; set; }
        public virtual AppUser User { get; set; }
    }
}

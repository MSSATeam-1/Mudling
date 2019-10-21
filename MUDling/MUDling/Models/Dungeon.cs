namespace MUDling.Models
{
    public class Dungeon
    {
        public int DungeonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Event { get; set; }
        public int AppUserId { get; set; } // foreign key UserId from AppUser
    }
}
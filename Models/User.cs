namespace TicketingAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // Client sau Manager
    }
}
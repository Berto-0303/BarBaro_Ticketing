namespace TicketingAPI.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Pending"; // Default value
        public int UserID { get; set; }
        public int CategoryID { get; set; }
    }
}
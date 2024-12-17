public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; } // High, Medium, Low
    public string Status { get; set; }  // Open, In Progress, Done
    public string Owner { get; set; }  // Nume utilizator (Client sau Manager)
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

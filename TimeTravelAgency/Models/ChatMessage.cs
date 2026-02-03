namespace TimeTravelAgency.Models;

public class ChatMessage
{
    public string Role { get; set; } = "user"; // "user" ou "assistant"
    public string Content { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

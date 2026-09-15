namespace server.Models;

public enum TaskType
{
    Gathering,
    Crafting,
    Hunting,
    Questing
}

public class UserTask
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public TaskType Type { get; set; }
    public string TaskIdentifier { get; set; } = string.Empty; // e.g., "MINE_COPPER"
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsCompleted { get; set; } = false;
}
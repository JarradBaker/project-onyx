namespace server.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Progression
    public int GlobalLevel { get; set; } = 1;
    public long GlobalXp { get; set; } = 0;
    public int UnallocatedStatPoints { get; set; } = 0;

    // Custom Character Attributes (Replace names to match your design)
    public int StatA { get; set; } = 10;
    public int StatB { get; set; } = 10;
    public int StatC { get; set; } = 10;
    public int StatD { get; set; } = 10;

    // Navigation Properties
    public List<UserSkill> Skills { get; set; } = new();
    public UserTask? ActiveTask { get; set; }
}
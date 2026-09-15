namespace server.Models;

public enum SkillType
{
    Gathering,
    Crafting,
    Hunting
}

public class UserSkill
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public SkillType Type { get; set; }
    public int Level { get; set; } = 1;
    public long Xp { get; set; } = 0;
}
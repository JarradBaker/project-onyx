using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/user/seed
    // Creates a test player in SQLite if none exists
    [HttpPost("seed")]
    public async Task<IActionResult> SeedUser()
    {
        // Check if a user already exists
        var existingUser = await _context.Users
            .Include(u => u.Skills)
            .Include(u => u.ActiveTask)
            .FirstOrDefaultAsync();

        if (existingUser != null)
        {
            return Ok(new { Message = "Test user already exists!", User = existingUser });
        }

        // Create default player profile with initial skills
        var testUser = new User
        {
            Username = "DarkAdventurer",
            Email = "player@realm.com",
            GlobalLevel = 1,
            GlobalXp = 0,
            UnallocatedStatPoints = 5,
            StatA = 10,
            StatB = 10,
            StatC = 10,
            StatD = 10,
            Skills = new List<UserSkill>
            {
                new UserSkill { Type = SkillType.Gathering, Level = 1, Xp = 0 },
                new UserSkill { Type = SkillType.Crafting, Level = 1, Xp = 0 },
                new UserSkill { Type = SkillType.Hunting, Level = 1, Xp = 0 }
            }
        };

        _context.Users.Add(testUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = testUser.Id }, testUser);
    }

    // GET: api/user/1
    // Fetches the player state, skills, and current active task
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.Skills)
            .Include(u => u.ActiveTask)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return NotFound(new { Message = $"User with ID {id} not found." });
        }

        return Ok(user);
    }
}
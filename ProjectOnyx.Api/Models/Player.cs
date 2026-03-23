namespace ProjectOnyx.Api.Models
{
    public class Player
    {
        public int Id { get; set; } 
        public string Username { get; set; } = string.Empty;
        
        // Progression
        public int Level { get; set; } = 1;
        public int Xp { get; set; } = 0;
        public int Gold { get; set; } = 0;

        // Base Combat Stats (Naked/Unequipped)
        public int MaxHealth { get; set; } = 100;
        public int CurrentHealth { get; set; } = 100;
        public int BaseAttack { get; set; } = 5;
        public int BaseDefense { get; set; } = 5;
        public int BaseMagicAttack { get; set; } = 0;
        public int BaseMagicResist { get; set; } = 0;
    }
}
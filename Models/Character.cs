namespace DnDCharacterManager.Models
{
    public class Character
    {
        public int Id { get; set; }

        //Character Details
        public string Name { get; set; }

        //Character Stats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        //Character possessions
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<Ability> Abilities { get; set; } = new List<Ability>();
    }
}

using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }

        //Character Details
        public string Name { get; set; } = string.Empty;

        //Character Stats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        //Character possessions
        public List<ItemDto> Items { get; set; } = new();
        public List<AbilityDto> Abilities { get; set; } = new();
    }
}

namespace DnDCharacterManager.DTOs
{
    public class CharacterCreateDto
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public List<AbilityCreateDto> Abilities { get; set; } = new();
        public List<ItemCreateDto> Items { get; set; } = new();
    }
}

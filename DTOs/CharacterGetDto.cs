namespace DnDCharacterManager.DTOs
{
    public class CharacterGetDto
    {
        //Character Details
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }

        //Character possessions
        public List<ItemDto> Items { get; set; } = new();
        public List<AbilityDto> Abilities { get; set; } = new();
    }
}

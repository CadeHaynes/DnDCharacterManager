using DnDCharacterManager.Models;

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

        // This would need a reference to the user at some point.

        public static Character ToCharacter(CharacterCreateDto dto)
        {
            var character = new Character
            {
                Name = dto.Name,
                Strength = dto.Strength,
                Dexterity = dto.Dexterity,
                Constitution = dto.Constitution,
                Intelligence = dto.Intelligence,
                Wisdom = dto.Wisdom,
                Charisma = dto.Charisma,

                Abilities = dto.Abilities.Select(a => new Ability
                {
                    Name = a.Name,
                    Description = a.Description
                }).ToList(),

                Items = dto.Items.Select(i => new Item
                {
                    Name = i.Name,
                    Description = i.Description
                }).ToList()
            };

            return character;
        }
    }
}

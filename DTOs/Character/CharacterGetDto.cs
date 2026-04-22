using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class CharacterGetDto
    {
        //Character Details
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }


        //Character possessions
        public List<ItemGetDto> Items { get; set; } = new();
        public List<AbilityGetDto> Abilities { get; set; } = new();

        public static CharacterGetDto FromCharacter(Character character)
        {
            var dto = new CharacterGetDto()
            {
                Id = character.Id,
                Name = character.Name,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Constitution = character.Constitution,
                Intelligence = character.Intelligence,
                Wisdom = character.Wisdom,
                Charisma = character.Charisma,

                Abilities = character.Abilities.Select(a => AbilityGetDto.FromAbility(a)).ToList(),

                Items = character.Items.Select(i => ItemGetDto.FromItem(i)).ToList()
            };

            return dto;
        }
    }
}

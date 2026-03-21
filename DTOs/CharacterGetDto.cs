using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class CharacterGetDto
    {
        //Character Details
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }

        //Character possessions
        public List<ItemDto> Items { get; set; } = new();
        public List<AbilityGetDto> Abilities { get; set; } = new();

        public static CharacterGetDto FromCharacter(Character character)
        {
            var dto = new CharacterGetDto()
            {
                Id = character.Id,
                Name = character.Name,

                Abilities = character.Abilities.Select(a => AbilityGetDto.FromAbility(a)).ToList(),

                Items = character.Items.Select(i => new ItemDto
                {
                    Name = i.Name,
                    Description = i.Description,
                    CharacterId = i.CharacterId
                }).ToList()
            };

            return dto;
        }
    }
}

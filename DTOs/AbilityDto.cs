using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class AbilityDto
    {
        // Ability Info
        public string Name { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }

        public static AbilityDto FromAbility(Ability ability)
        {
            var dto = new AbilityDto()
            {
                Name = ability.Name,
                Description = ability.Description
            };

            return dto;
        }
    }
}

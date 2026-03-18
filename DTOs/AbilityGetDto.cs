using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class AbilityGetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static AbilityGetDto FromAbility(Ability ability)
        {
            var dto = new AbilityGetDto
            {
                Name = ability.Name,
                Description = ability.Description
            };

            return dto;
        }
    }
}

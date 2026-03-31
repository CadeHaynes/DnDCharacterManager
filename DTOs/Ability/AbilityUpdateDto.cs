using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class AbilityUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static Ability UpdateAbility(AbilityUpdateDto dto, Ability ability)
        {
            ability.Name = dto.Name;
            ability.Description = dto.Description;

            return ability;
        }
    }
}

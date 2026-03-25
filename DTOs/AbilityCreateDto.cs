using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class AbilityCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static Ability ToAbility(AbilityCreateDto dto)
        {
            var ability = new Ability
            {
                Name = dto.Name,
                Description = dto.Description
            };

            return ability;
        }
    }
}

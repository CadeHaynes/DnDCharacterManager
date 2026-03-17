using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class CharacterUpdateDto
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public static Character UpdateCharacter(CharacterUpdateDto dto, Character character)
        {
            character.Name = dto.Name;
            character.Strength = dto.Strength;
            character.Dexterity = dto.Dexterity;
            character.Constitution = dto.Constitution;
            character.Intelligence = dto.Intelligence;
            character.Wisdom = dto.Wisdom;
            character.Charisma = dto.Charisma;

            return character;
        }
    }
}

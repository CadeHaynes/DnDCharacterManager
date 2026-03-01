using System.Text.Json.Serialization;

namespace DnDCharacterManager.Models
{
    public class Ability
    {
        // Ability Info
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Character Info
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }
    }
}

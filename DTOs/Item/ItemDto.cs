using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class ItemDto
    {
        // Item Info
        public string Name { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }

        public static ItemDto FromItem(Item item)
        {
            var dto = new ItemDto()
            {
                Name = item.Name,
                Description = item.Description,
                CharacterId = item.CharacterId
            };

            return dto;
        }
    }
}

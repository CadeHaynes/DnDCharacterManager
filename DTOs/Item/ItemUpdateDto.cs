using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class ItemUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static Item UpdateItem(ItemUpdateDto dto, Item item)
        {
            item.Name = dto.Name;
            item.Description = dto.Description;

            return item;
        }
    }
}

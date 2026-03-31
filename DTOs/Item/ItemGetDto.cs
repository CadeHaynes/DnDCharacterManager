using DnDCharacterManager.Models;

namespace DnDCharacterManager.DTOs
{
    public class ItemGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ItemGetDto FromItem(Item item)
        {
            var dto = new ItemGetDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            return dto;
        }
    }
}

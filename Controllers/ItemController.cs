using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
using DnDCharacterManager.DTOs;

namespace DnDCharacterManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("character/{characterId}")]
        public async Task<ActionResult<IEnumerable<ItemGetDto>>> GetItemsForCharacter(int characterId)
        {
            var items = await _context.Items
                .Where(i => i.CharacterId == characterId)
                .ToListAsync();

            var itemDtos = items.Select(i => ItemGetDto.FromItem(i)).ToList();

            return itemDtos;
        }
    }
}

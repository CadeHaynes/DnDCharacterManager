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

        [HttpGet("character/{characterId}/items/{itemIndex}")]
        public async Task<ActionResult<ItemGetDto>> GetSelectedItemForCharacter(int characterId, int itemIndex)
        {
            var item = await _context.Items
                .Where(i => i.CharacterId == characterId)
                .OrderBy(i => i.Id)
                .Skip(itemIndex)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return ItemGetDto.FromItem(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGetDto>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return ItemGetDto.FromItem(item);
        }

        [HttpPost("character/{characterId}")]
        public async Task<ActionResult<ItemCreateDto>> PostItemForCharacter(int characterId, ItemCreateDto dto)
        {
            var item = ItemCreateDto.ToItem(dto);
            item.CharacterId = characterId;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, ItemGetDto.FromItem(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItem(int id, ItemUpdateDto dto)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item = ItemUpdateDto.UpdateItem(dto, item);

            await _context.SaveChangesAsync();

            return ItemDto.FromItem(item);
        }

        [HttpPut("character/{characterId}/items/{itemIndex}")]
        public async Task<ActionResult<ItemDto>> UpdateSelectedItemForCharacter(int characterId, int itemIndex, ItemUpdateDto dto)
        {
            var item = await _context.Items
                .Where(i => i.CharacterId == characterId)
                .OrderBy(i => i.Id)
                .Skip(itemIndex)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            item = ItemUpdateDto.UpdateItem(dto, item);

            await _context.SaveChangesAsync();

            return ItemDto.FromItem(item);
        }

        [HttpDelete("character/{characterId}/items/{itemIndex}")]
        public async Task<IActionResult> DeleteSelectedItemForCharacter(int characterId, int itemIndex)
        {
            var item = await _context.Items
                .Where(i => i.CharacterId == characterId)
                .OrderBy(i => i.Id)
                .Skip(itemIndex)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("character/{characterId}")]
        public async Task<IActionResult> DeleteAllItemsForCharacter(int characterId)
        {
            var items = await _context.Items
                .Where(i => i.CharacterId == characterId)
                .ToListAsync();

            if (!items.Any())
            {
                return NotFound();
            }

            foreach (var item in items)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
using DnDCharacterManager.DTOs;
using DnDCharacterManager.Models;

namespace DnDCharacterManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterGetDto>>> GetCharacters()
        {
            // Gets the characters and their abilities/items.
            var characters = await _context.Characters
                .Include(c => c.Abilities)
                .Include(c => c.Items)
                .ToListAsync();

            var characterDtos = characters.Select(c => CharacterGetDto.FromCharacter(c)).ToList();

            return characterDtos;
        }

        // GET: api/Character/[number]
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterGetDto>> GetCharacter(int id)
        {
            // Gets all the characters, then sets character to the character (if any) whose ID matches the id parameter.
            var character = await _context.Characters
                .Include(c => c.Abilities)
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            var result = CharacterGetDto.FromCharacter(character);

            return result;
        }

        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDto dto)
        {
            var character = CharacterCreateDto.ToCharacter(dto);

            // Adds the character to the database, then waits for the context to save the changes before returning.
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var result = CharacterDto.FromCharacter(character);

            // Uses GetCharacter to confirm character exists in database.
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, result);
        }

        // DELETE: api/Character
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            // Sets character to the character (if any) whose ID matches the id parameter, then deletes that character.
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Character/[number]
        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDto>> UpdateCharacter(int id, CharacterUpdateDto dto)
        {
            var character = await _context.Characters
                .Include(c => c.Abilities)
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            character = CharacterUpdateDto.UpdateCharacter(dto, character);

            await _context.SaveChangesAsync();

            return CharacterDto.FromCharacter(character);
        }
    }
}

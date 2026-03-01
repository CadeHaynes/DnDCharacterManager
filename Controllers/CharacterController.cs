using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
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
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            // Gets the characters and their abilities/items.
            var characters = await _context.Characters
                .Include(c => c.Abilities)
                .Include(c => c.Items)
                .ToListAsync();

            return characters;
        }

        // GET: api/Character/[number]
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
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

            return character;
        }

        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            // Adds the character to the database, then waits for the context to save the changes before returning.
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            // Uses GetCharacter to confirm character exists in database.
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
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
    }
}

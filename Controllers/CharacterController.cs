using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
using DnDCharacterManager.DTOs;
using DnDCharacterManager.Models;
using System.Reflection.Metadata.Ecma335;

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

            var characterDtos = characters.Select(c => CharactertoGetDTO(c)).ToList();

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

            var result = CharactertoGetDTO(character);

            return result;
        }

        // POST: api/Character
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDto dto)
        {
            var character = DTOtoCharacterCreate(dto);

            // Adds the character to the database, then waits for the context to save the changes before returning.
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var result = CharactertoDTO(character);

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

        Character DTOtoCharacterCreate(CharacterCreateDto dto)
        {
            var character = new Character
            {
                Name = dto.Name,
                Strength = dto.Strength,
                Dexterity = dto.Dexterity,
                Constitution = dto.Constitution,
                Intelligence = dto.Intelligence,
                Wisdom = dto.Wisdom,
                Charisma = dto.Charisma,

                Abilities = dto.Abilities.Select(a => new Ability
                {
                    Name = a.Name,
                    Description = a.Description
                }).ToList(),
                
                Items = dto.Items.Select(i => new Item
                {
                    Name = i.Name,
                    Description = i.Description
                }).ToList()
            };

            return character;
        }

        CharacterDto CharactertoDTO(Character character)
        {
            var result = new CharacterDto()
            {
                Id = character.Id,

                Name = character.Name,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Constitution = character.Constitution,
                Intelligence = character.Intelligence,
                Wisdom = character.Wisdom,
                Charisma = character.Charisma,

                Abilities = character.Abilities.Select(a => new AbilityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                }).ToList(),

                Items = character.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description
                }).ToList()
            };

            return result;
        }
        CharacterGetDto CharactertoGetDTO(Character character)
        {
            var result = new CharacterGetDto()
            {
                Name = character.Name,

                Abilities = character.Abilities.Select(a => new AbilityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                }).ToList(),

                Items = character.Items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description
                }).ToList()
            };

            return result;
        }
    }
}

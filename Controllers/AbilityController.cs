using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
using DnDCharacterManager.DTOs;
using DnDCharacterManager.Models;

namespace DnDCharacterManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbilityController : ControllerBase
    {
        readonly AppDbContext _context;

        public AbilityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("character/{characterId}")]
        public async Task<ActionResult<IEnumerable<AbilityGetDto>>> GetAbilitiesForCharacter(int characterId)
        {
            var abilities = await _context.Abilities
                .Where(a => a.CharacterId == characterId)
                .ToListAsync();

            var abilityDtos = abilities.Select(a => AbilityGetDto.FromAbility(a)).ToList();

            return abilityDtos;
        }

        [HttpGet("character/{characterId}/abilities/{abilityIndex}")]
        public async Task<ActionResult<AbilityGetDto>> GetSelectedAbilityForCharacter(int characterId, int abilityIndex)
        {
            var ability = await _context.Abilities
                .Where(a => a.CharacterId == characterId)
                .OrderBy(a => a.Id)
                .Skip(abilityIndex)
                .FirstOrDefaultAsync();

            if (ability == null)
            {
                return NotFound();
            }

            return AbilityGetDto.FromAbility(ability);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbilityGetDto>> GetAbility(int id)
        {
            var ability = await _context.Abilities.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return AbilityGetDto.FromAbility(ability);
        }

        [HttpPost("character/{characterId}")]
        public async Task<ActionResult<AbilityCreateDto>> PostAbilityForCharacter(int characterId, AbilityCreateDto dto)
        {
            var ability = AbilityCreateDto.ToAbility(dto);
            ability.CharacterId = characterId;

            _context.Abilities.Add(ability);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAbility), new { id = ability.Id }, AbilityGetDto.FromAbility(ability));
        }
    }
}

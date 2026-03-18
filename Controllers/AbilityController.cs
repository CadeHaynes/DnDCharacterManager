using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;
using DnDCharacterManager.DTOs;

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

        [HttpGet("character/{characterId}/abilities/{abilityId}")]
        public async Task<ActionResult<AbilityGetDto>> GetSelectedAbilityForCharacter(int characterId, int abilityId)
        {
            var ability = await _context.Abilities
                .Where(a => a.Character.Id == characterId && a.Id == abilityId)
                .FirstOrDefaultAsync();

            if (ability == null)
            {
                return NotFound();
            }

            return AbilityGetDto.FromAbility(ability);
        }
    }
}

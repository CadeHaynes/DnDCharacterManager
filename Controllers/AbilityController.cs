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

            var abilityDtos = abilities.Select(a => AbilityToGetDto(a)).ToList();

            return abilityDtos;
        }

        AbilityGetDto AbilityToGetDto(Ability ability)
        {
            var result = new AbilityGetDto()
            {
                Name = ability.Name,
                Description = ability.Description
            };

            return result;
        }
    }
}

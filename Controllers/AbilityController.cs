using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DnDCharacterManager.Data;

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

        //[HttpGet("{id}")]

    }
}

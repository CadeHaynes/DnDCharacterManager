using DnDCharacterManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Ability> Abilities { get; set; }
    }
}

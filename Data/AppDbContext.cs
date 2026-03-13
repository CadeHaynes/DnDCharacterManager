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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
                .HasMany(e => e.Abilities)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharacterId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Character>()
                .HasMany(e => e.Items)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharacterId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}

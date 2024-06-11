using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
            {
                new Backpack {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 3
                },
                new Backpack {
                    CharacterId = 2,
                    ItemId = 2,
                    Amount = 5
                }
            });

            modelBuilder.Entity<Character>().HasData(new List<Character>
            {
                new Character {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    CurrentWeight = 40,
                    MaxWeight = 100
                },
                new Character {
                    Id = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska",
                    CurrentWeight = 55,
                    MaxWeight = 120
                }
            });

            modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
            {
                new CharacterTitle
                {
                    CharacterId = 1,
                    TileId = 1,
                    AquiredAt = DateTime.Parse("2024-06-11")
                },
                new CharacterTitle
                {
                    CharacterId = 1,
                    TileId = 2,
                    AquiredAt = DateTime.Parse("2024-12-01")
                },
                new CharacterTitle
                {
                    CharacterId = 2,
                    TileId = 1,
                    AquiredAt = DateTime.Parse("2014-04-01")
                }
            });

            modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "rock",
                    Weight = 12
                },
                new Item
                {
                    Id = 2,
                    Name = "flint",
                    Weight = 4
                },
                new Item
                {
                    Id = 3,
                    Name = "gold",
                    Weight = 20
                }
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title
                {
                    Id = 1,
                    Name = "fighter"
                },
                new Title
                {
                    Id = 2,
                    Name = "victor"
                },
                new Title
                {
                    Id = 3,
                    Name = "master"
                }
            });
    }
}
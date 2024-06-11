using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<GetCharacterDto?> GetCharacterInfo(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Where(c => c.Id == characterId)
            .FirstOrDefaultAsync();
            
        if (character == null)
        {
            return null;
        }

        return new GetCharacterDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new GetBackpackItemsDto
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(ct => new GetTitleDto()
            {
                Title = ct.Title.Name,
                AquiredAt = ct.AquiredAt
            }).ToList()

        };
    }
    
    public async Task AddCharacterItem(Backpack backpack)
    {
        await _context.AddAsync(backpack);
        await _context.SaveChangesAsync();
    }

    
}
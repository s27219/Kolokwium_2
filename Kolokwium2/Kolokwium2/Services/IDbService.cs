using Kolokwium2.DTOs;
using Kolokwium2.Models;

namespace Kolokwium2.Services;

public interface IDbService
{
    public Task<GetCharacterDto?> GetCharacterInfo(int characterId);
    public Task AddCharacterItem(Backpack backpack);
}
using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IDbService
{
    public Task<GetCharacterDto?> GetCharacterInfo(int characterId);
    
}
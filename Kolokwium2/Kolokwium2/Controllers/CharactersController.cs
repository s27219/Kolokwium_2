using Kolokwium2.DTOs;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<ActionResult<GetCharacterDto>> GetPatient(int characterId)
    {
        var character = await _dbService.GetCharacterInfo(characterId);

        if (character == null)
            return NotFound("Character not found");

        return Ok(character);
    }
}
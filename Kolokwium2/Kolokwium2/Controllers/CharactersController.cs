using System.Transactions;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
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

    [HttpPost("{characterId}")]
    public async Task<IActionResult> AddCharacterItem(int characterId, AddItemDto addItemDto)
    {
        Backpack b = new Backpack();
        /*Backpack b = new Backpack
        {
            Amount = addItemDto,
            ItemId = addItemDto.ItemId,
            CharacterId = addItemDto
        };*/
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddCharacterItem(b);

            scope.Complete();
        }

        return Created();
    }
}
namespace Kolokwium2.DTOs;

public class GetCharacterDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public List<GetBackpackItemsDto> BackpackItems { get; set; }
    public List<GetTitleDto> Titles { get; set; }
}

public class GetBackpackItemsDto
{
    public string ItemName { get; set; } = string.Empty;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }

}

public class GetTitleDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime AquiredAt { get; set; }
}
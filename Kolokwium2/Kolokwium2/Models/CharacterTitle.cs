using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TileId))]
public class CharacterTitle
{
    public int CharacterId { get; set; }
    public int TileId { get; set; }
    public DateTime AquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(TileId))]
    public Title Title { get; set; } = null!;
}
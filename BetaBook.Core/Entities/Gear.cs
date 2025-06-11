using SQLite;

namespace BetaBook.Core.Entities;

[Table("gear")]
public class Gear {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("manufacturer")]
    public string? Manufacturer { get; set; } = null;

    // required
    // active/passive
    [Column("type")]
    public string? Type { get; set; }

    // required
    [Column("description")]
    public string? Description { get; set; }

    [Column("size")]
    public string? Size { get; set; } = null;
}

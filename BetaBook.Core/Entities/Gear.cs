using SQLite;

namespace BetaBook.Core.Entities;

[Table("gear")]
public class Gear {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("manufacturer_id")]
    public int? ManufacturerId { get; set; } = null;

    // required
    [Column("description")]
    public string? Description { get; set; }
}

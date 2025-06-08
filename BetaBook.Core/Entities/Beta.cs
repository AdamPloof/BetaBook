using SQLite;

namespace BetaBook.Core.Entities;

[Table("beta")]
public class Beta {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("move_number")]
    public int MoveNumber { get; set; }

    // required
    [Column("description")]
    public string? Description { get; set; }

    [Column("gear_id")]
    public int? GearId { get; set; } = null;
}

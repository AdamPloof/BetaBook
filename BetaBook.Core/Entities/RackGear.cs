using SQLite;

namespace BetaBook.Core.Entities;

/// <summary>
/// Many to many table for gear on a rack
/// </summary>
[Table("rack_gear")]
public class RackGear {
    [Column("rack_id")]
    public int RackId { get; set; }

    [Column("gear_id")]
    public int GearId { get; set; }
}

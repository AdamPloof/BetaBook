using SQLite;

namespace BetaBook.Core.Entities;

[Table("manufacturer")]
public class Manufacturer {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    // required
    [Column("name")]
    public string? Name { get; set; }
}

using SQLite;

namespace BetaBook.Core.Entities;

[Table("crag")]
public class Crag {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    // required
    [Column("name")]
    public string? Name { get; set; }
}

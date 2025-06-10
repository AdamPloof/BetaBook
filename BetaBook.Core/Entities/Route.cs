using SQLite;
using System.Collections.Generic;

namespace BetaBook.Core.Entities;

[Table("route")]
public class Route {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    // required
    [Column("name")]
    public string? Name { get; set; }

    [Ignore]
    public List<Pitch> Pitches { get; set; } = [];
}

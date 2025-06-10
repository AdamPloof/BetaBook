using SQLite;
using System.Collections.Generic;

namespace BetaBook.Core.Entities;

[Table("pitch")]
public class Pitch {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("pitch_number")]
    public int PitchNumber { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Ignore]
    public List<PitchSection> Sections { get; set; } = [];
}

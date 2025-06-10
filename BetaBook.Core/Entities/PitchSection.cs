using SQLite;
using System.Collections.Generic;

namespace BetaBook.Core.Entities;

[Table("pitch_section")]
public class PitchSection {
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("section_number")]
    public int SectionNumber { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Ignore]
    public List<Beta> Beta { get; set; } = [];
}

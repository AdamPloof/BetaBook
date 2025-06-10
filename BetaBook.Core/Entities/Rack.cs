using SQLite;
using System.Collections.Generic;

namespace BetaBook.Core.Entities;

[Table("rack")]
public class Rack {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Ignore]
    public List<Gear> Gear { get; set; } = [];
}

using System.Collections.Generic;
using Xunit;

using BetaBook.Core.Data;
using BetaBook.Core.Entities;

namespace BetaBook.Tests.Data;

public class GearSeederTests {
    [Fact]
    public async Task GearIsLoaded() {
        TestDbConfigProvider dbConfig = new("gear_loaded_");
        DbManager db = new DbManager(dbConfig);

        try {
            await GearSeeder.LoadGear(db, dbConfig.GetGearDataPath());
            IEnumerable<Gear> gear = await db.FindAllAsync<Gear>();
            Assert.NotEmpty(gear);
        } finally {
            await db.EnsureReadyAsync();
            string dbPath = dbConfig.GetDatabasePath();
            if (File.Exists(dbPath)) {
                File.Delete(dbPath);
            }
        }
    }

    [Fact]
    public async Task GearIsCorrect() {
        TestDbConfigProvider dbConfig = new("gear_correct_");
        DbManager db = new DbManager(dbConfig);

        try {
            await GearSeeder.LoadGear(db, dbConfig.GetGearDataPath());
            IEnumerable<Gear> gear = await db.FindAllAsync<Gear>();
            Gear cam = gear.Where(g =>
                g.Manufacturer == "Black Diamond"
                && g.Description == "Camalot C4"
                && g.Size == "2"
            ).Single();
            Assert.Equal("Black Diamond", cam.Manufacturer);
            Assert.Equal("Camalot C4", cam.Description);
            Assert.Equal("2", cam.Size);
        } finally {
            await db.EnsureReadyAsync();
            string dbPath = dbConfig.GetDatabasePath();
            if (File.Exists(dbPath)) {
                File.Delete(dbPath);
            }
        }
    }
}

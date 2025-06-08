using SQLite;
using System.Collections.Generic;

using BetaBook.Core.Entities;

namespace BetaBook.UI.Data;

public class DbManager {
    private SQLiteAsyncConnection? _db;
    
    public DbManager() {
        string dbDir = FileSystem.AppDataDirectory;
        string dbPath = Path.Combine(dbDir, "beta.db");
        var dbOptions = new SQLiteConnectionString(dbPath);
        _db = new SQLiteAsyncConnection(dbOptions);

        _ = Init();
    }

    async Task Init() {
        if (_db is not null) {
            return;
        }

        _db = new SQLiteAsyncConnection("");
        await _db.CreateTableAsync<Beta>();
        await _db.CreateTableAsync<PitchSection>();
        await _db.CreateTableAsync<Pitch>();
        await _db.CreateTableAsync<Route>();
        await _db.CreateTableAsync<Crag>();
        await _db.CreateTableAsync<Manufacturer>();
        await _db.CreateTableAsync<Gear>();
        await _db.CreateTableAsync<Rack>();
        await _db.CreateTableAsync<RackGear>();
    }
}

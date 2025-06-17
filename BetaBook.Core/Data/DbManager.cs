using SQLite;
using System.Collections.Generic;

using BetaBook.Core.Entities;

namespace BetaBook.Core.Data;

public class DbManager {
    private SQLiteAsyncConnection _db;
    
    public DbManager(IDbConfigProvider config) {
        var dbOptions = new SQLiteConnectionString(config.GetDatabasePath());
        _db = new SQLiteAsyncConnection(dbOptions);

        _ = Init();
    }

    async Task Init() {
        await _db.CreateTableAsync<Beta>();
        await _db.CreateTableAsync<PitchSection>();
        await _db.CreateTableAsync<Pitch>();
        await _db.CreateTableAsync<Route>();
        await _db.CreateTableAsync<Crag>();
        await _db.CreateTableAsync<Gear>();
        await _db.CreateTableAsync<Rack>();
        await _db.CreateTableAsync<RackGear>();
    }

    public async Task AddAsync<T>(T entity) {
        await _db.InsertAsync(entity);
    }

    public async Task<T?> FindAsync<T>(int id) where T: new() {
        return await _db.FindAsync<T>(id);
    }

    public async Task<IEnumerable<T>> FindAllAsync<T>() where T: new() {
        return await _db.Table<T>().ToListAsync();
    }

    public async Task<bool> RemoveAsync<T>(T entity) {
        int result = await _db.DeleteAsync(entity);

        return result > 0;
    }
}

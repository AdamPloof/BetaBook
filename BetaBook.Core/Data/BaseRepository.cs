using SQLite;

namespace BetaBook.Core.Data;

public class BaseRepository<T> : IRepository<T> where T : new() {
    private readonly DbManager _db;

    public BaseRepository(DbManager db) {
        _db = db;
    }

    public async Task<T?> FindAsync(int id) {
        return await _db.FindAsync<T>(id);
    }

    public async Task<IEnumerable<T>> FindAllAsync() {
        return await _db.FindAllAsync<T>();
    }
}

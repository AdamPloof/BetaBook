using SQLite;

namespace BetaBook.Core.Data;

public class BaseRepository<T> : IRepository<T> where T : new() {
    private readonly SQLiteAsyncConnection _db;

    public BaseRepository(SQLiteAsyncConnection db) {
        _db = db;
    }

    public async Task AddAsync(T entity) {
        await _db.InsertAsync(entity);
    }

    public async Task<T?> FindAsync(int id) {
        return await _db.FindAsync<T>(id);
    }

    public async Task<IEnumerable<T>> FindAllAsync() {
        return await _db.Table<T>().ToListAsync();
    }

    public async Task<bool> RemoveAsync(T entity) {
        int result = await _db.DeleteAsync(entity);

        return result > 0;
    }
}

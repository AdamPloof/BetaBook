using SQLite;

namespace BetaBook.Core.Data;

public class RepositoryFactory {
    private readonly SQLiteAsyncConnection _db;

    public RepositoryFactory(SQLiteAsyncConnection db) {
        _db = db;
    }

    public IRepository<T> Create<T>() where T : new() {
        return new BaseRepository<T>(_db);
    }
}

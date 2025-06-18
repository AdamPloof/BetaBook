using SQLite;

namespace BetaBook.Core.Data;

public class RepositoryFactory {
    private readonly DbManager _db;

    public RepositoryFactory(DbManager db) {
        _db = db;
    }

    public IRepository<T> Create<T>() where T : new() {
        return new BaseRepository<T>(_db);
    }
}

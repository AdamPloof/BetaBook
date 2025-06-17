using BetaBook.Core.Data;

namespace BetaBook.UI.Services;

public class MauiDbConfigProvider : IDbConfigProvider {
    public string GetDatabasePath() {
        string dbDir = FileSystem.AppDataDirectory;

        return Path.Combine(dbDir, "beta.db");;
    }
}

using BetaBook.Core.Data;

namespace BetaBook.UI.Services;

public class MauiDbConfigProvider : IDbConfigProvider {
    public string GetDatabasePath() {
        return Path.Combine(FileSystem.AppDataDirectory, "beta.db");;
    }

    public string GetGearDataPath() {
        // TODO: update to resources directory
        return Path.Combine(FileSystem.AppDataDirectory, "gear.json");;
    }
}

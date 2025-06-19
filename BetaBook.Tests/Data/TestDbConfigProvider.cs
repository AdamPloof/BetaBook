using System.IO;

using BetaBook.Core.Data;

namespace BetaBook.Tests.Data;

public class TestDbConfigProvider : IDbConfigProvider {
    private readonly string _dbId;

    public TestDbConfigProvider(string dbId = "test_") {
        _dbId = dbId;
    }

    public string GetDatabasePath() {
        string baseDir = AppContext.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"../../../"));

        return Path.Combine(projectRoot, $"var/{_dbId}beta.db");
    }

    public string GetGearDataPath() {
        string baseDir = AppContext.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"../../../"));

        return Path.Combine(projectRoot, $"var/testGear.json");
    }
}
using System;
using System.IO;
using Xunit;
using BetaBook.Core.Data;

namespace BetaBook.Tests.Data;

public class TestDbConfigProvider : IDbConfigProvider {
    public string GetDatabasePath() {
        string baseDir = AppContext.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"../../../"));
        string dbPath = Path.Combine(projectRoot, "var/beta.db");

        return dbPath;
    }

    public string GetGearDataPath() {
        return "";
    }
}

public class DbManagerTests : IDisposable {
    private readonly IDbConfigProvider _dbConfig;

    public DbManagerTests() {
        _dbConfig = new TestDbConfigProvider();
    }

    [Fact]
    public void DbIsCreated() {
        DbManager _ = new DbManager(_dbConfig);
        string dbPath = _dbConfig.GetDatabasePath();
        Assert.True(File.Exists(dbPath));
    }

    public void Dispose() {
        string dbPath = _dbConfig.GetDatabasePath();
        if (File.Exists(dbPath)) {
            File.Delete(dbPath);
        }
    }
}

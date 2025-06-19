using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Xunit;

using BetaBook.Core.Data;
using BetaBook.Core.Entities;

namespace BetaBook.Tests.Data;

public class DbManagerTests {
    [Fact]
    public async void DbIsCreated() {
        TestDbConfigProvider dbConfig = new("db_created_");
        DbManager db = new DbManager(dbConfig);
        await db.EnsureReadyAsync();
        string dbPath = dbConfig.GetDatabasePath();

        try {
            Assert.True(File.Exists(dbPath));
        } finally {
            if (File.Exists(dbPath)) {
                File.Delete(dbPath);
            }
        }
    }

    [Fact]
    public async Task BetaInserted() {
        TestDbConfigProvider dbConfig = new("beta_inserted_");
        DbManager db = new DbManager(dbConfig);
        Beta beta = new Beta() {
            MoveNumber = 1,
            Description = "Foo"
        };
        await db.AddAsync(beta);
        IEnumerable<Beta> allBeta = await db.FindAllAsync<Beta>();

        try {
            Assert.NotEmpty(allBeta);
        } finally {
            string dbPath = dbConfig.GetDatabasePath();
            if (File.Exists(dbPath)) {
                File.Delete(dbPath);
            }
        }
    }
}

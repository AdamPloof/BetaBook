namespace BetaBook.Core.Data;

/// <summary>
/// Provides methods for getting configuration needed for database connections
/// and setup.
/// </summary>
public interface IDbConfigProvider {
    /// <summary>
    /// Get the path to the SQLite database
    /// </summary>
    /// <returns></returns>
    public string GetDatabasePath();
}

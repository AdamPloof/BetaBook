namespace BetaBook.Core.Data;

/// <summary>
/// Repository interface for working with entities in the database
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> {
    /// <summary>
    /// Insert a new entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task AddAsync(T entity);

    /// <summary>
    /// Get a single instance of entity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<T?> FindAsync(int id);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<T>> FindAllAsync();

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>True if the entity was deleted sucessfully, otherwise false</returns>
    public Task<bool> RemoveAsync(T entity);
}

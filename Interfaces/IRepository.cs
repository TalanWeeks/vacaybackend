using System.Collections.Generic;

namespace vacaybackend.Interfaces
{
  // NOTE                      vv this is called a generic
  public interface IRepository<T>
  {
    /// <summary>
    /// Get all items in the collection
    /// </summary>
    List<T> Get();
    /// <summary>
    /// Get a single item by its id
    /// </summary>
    /// <param name="id"></param>
    T Get(int id);

    /// <summary>
    /// Adds data to the database and returns the data with its id
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    T Create(T data);

    /// <summary>
    /// Finds an item by its id and updates it to the passed in data
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    T Edit(int id, T data);

    /// <summary>
    /// Finds an item by its id to be removed
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);

  }
}
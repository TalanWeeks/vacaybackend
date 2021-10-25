
using System.Data;

namespace Bloggr.Repositories
{
  public class DbContext
  {
    protected readonly IDbConnection _db;

    public DbContext(IDbConnection db)
    {
      _db = db;
    }
  }
}
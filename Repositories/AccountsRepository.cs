using System.Data;
using Dapper;
using frog.Models;

namespace frog.Repositories
{
  public class AccountsRepository
  {
    private readonly IDbConnection _db;
    public AccountsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal AccountsRepository GetById(string id)
    {
      string sql = "SELECT * FROM accounts WHERE is = @id";
      return _db.QueryFirstOrDefault<Account>(sql, new { id });
    }
  }
}
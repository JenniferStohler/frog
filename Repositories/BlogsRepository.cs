using System;
using System.Collections.Generic;
using System.Data;
using frog.Models;
using Dapper;

namespace frog.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;
    private object newBlog;

    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Blog> GetAll()
    {
      string sql = "SELECT * FROM recipes";
      return _db.Query<Blog>(sql);
    }

    internal Blog GetById(int id)
    {
      string sql = "SELECT * FROM blogs WHERE id = @id";
      return _db.QueryFirstOrDefault<Blog>(sql, new { id });
    }

    internal Blog Create(Blog newRecipe)
    {
      string sql = @"
      INSERT INTO blogs
      (creatorId, name, description)
      VALUES
      (@CreatorId, @Name, @Description);
      SELECT LAST_INSERT_ID()";
      newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
      return newBlog;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1";
      int changedRows = _db.Execute(sql, new { id });
      return changedRows == 1;
    }

    internal bool Update(Blog original)
    {
      string sql = @"
      SET
        name = @Name,
        description = @Description 
        WHERE id = @id
      ";
      int changedRows = _db.Execute(sql, original);
      return changedRows == 1;
    }
  }

  internal class Blog
  {
    public object CreatorId { get; internal set; }
    public object Name { get; internal set; }
    public object Description { get; internal set; }
  }
}
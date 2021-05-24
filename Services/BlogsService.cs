using System;
using System.Collections.Generic;
using frog.Repositories;

namespace frog.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;

    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Blog> GetAll()
    {
      return _repo.GetAll();

    }

    internal Blog GetById(int id)
    {
      Blog blog = _repo.GetById(id);
      if (blog == null)
      {
        throw new Exception("Invalid blog id");

      }
      return blog;
    }
    internal Blog Update(Blog update)
    {
      Blog original = GetById(update.Id);

      if (update.CreatorId != original.CreatorId)
      {
        throw new Exception("You cant do that!");
      }

      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Description = update.Description.Length > 0 ? update.Description : original.Description;
      if (_repo.Update(original))
      {
        return original;
      }
      throw new Exception("Something went wrong");
    }

    internal void Delete(int id1, string id2)
    {
      Blog recipe = GetById(id);
      if (recipe.CreatorId != creatorId)
      {
        throw new Exception("You cannot delete another users blog!");
      }
      if (!_repo.Delete(id))
      {
        throw new Exception("Something has gone terribly wrong!");
      }
    }

    private Blog GetById(object id)
    {
      Blog blog = _repo.GetById(id);
      if (blog == null)
      {
        throw new Exception("Invalid blog id");

      }
      return blog;
    }

    internal Blog Create(object newBlog)
    {
      return _repo.Create(newBlog);

    }

    // internal System.Collections.Generic.IEnumerable<Blog> GetAll()
    // {
    //   throw new NotImplementedException();
    // }
  }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frog.Models;
using frog.Repositories;
using frog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frog.Controllers
{
  [ApiController]
  [Route("api/[controller")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _bService;
    private readonly AccountsService _aService;
    public BlogsController(BlogsService bService, AccountsService aService)
    {
      _bService = bService;
      _aService = aService;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Blog>> GetAll()
    {
      try
      {
        IEnumerable<Blog> blogs = _bService.GetAll();
        return Ok(blogs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]

    public ActionResult<Blog> GetById(int id)
    {
      try
      {
        Blog found = _bService.GetById(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Blog>> Create([FromBody] Blog newRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _aService.GetOrCreateAccount(userInfo);
        newBlog.CreatorId = userInfo.Id;
        Blog blog = _bService.Create(newBlog);
        return Ok(blog);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<Blog>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _bService.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Blog>> Update(int id, [FromBody] Blog update)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        update.CreatorId = userInfo.Id;
        update.Id = id;
        Blog updated = _bService.Update(update);
        return Ok(updated);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}


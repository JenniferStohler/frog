using System;
using System.Threading.Tasks;
using frog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frog.Controllers
{
  public class AccountsController
  {
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class AccountsController : ControllerBase
    {
      private readonly AccountsServices _service;

      public AccountsController()
      {
      }

      public AccountsController(AccountsServices service)
      {
        _service = service;
      }

      [HttpGet]

      public async Task<ActionResult<Account>> GetTask()
      {
        try
        {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          Account currentUser = _service.GetOrCreateAccount(userInfo);
          return Ok(currentUser);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
      }
    }
  }
}
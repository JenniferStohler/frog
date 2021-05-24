using System;
using System.Threading.Tasks;
using frog.Models;
using frog.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frog.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class AccountController : ControllerBase
  {
    private readonly AccountsService _service;

    public AccountController(AccountsService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<Account>> Get()
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

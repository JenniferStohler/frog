using System;

namespace frog.Services
{
  public class AccountsServices
  {
    private readonly AccountsRepository _rep;

    public AccountsServices(AccountsRepository repository) => _repo = repository;

    internal Account GetOrCreateAccount(Account userInfo)
    {
      throw new NotImplementedException();
    }
  }

  internal class AccountsRepository
  {
  }

  internal class Account GetOrCreateAccount(Account userInfo)
  {
    Account account = _repo.GetById(userInfo.Id);
    if (account == null)
    {
      return _repo.Create(userInfo);
    }
    return account;
  }
}
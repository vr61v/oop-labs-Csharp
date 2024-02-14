using System.Collections.Generic;
using System.Linq;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.BankAccount;

namespace Lab5.Infrastructure.DataAccessMoq.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private List<BankAccount> _accounts = new List<BankAccount>();

    public IEnumerable<BankAccount> FindBankAccountsByUserId(int userId)
    {
        return _accounts.Where(x => x.UserId == userId);
    }

    public BankAccount? FindBankAccountByAccountId(int bankAccountId)
    {
        return _accounts.Find(x => x.BankAccountId == bankAccountId);
    }

    public bool CreateAccount(int bankAccountId, int userId, int amount)
    {
        _accounts.Add(new BankAccount(bankAccountId, userId, amount));
        return true;
    }

    public bool ChangeAmountAccount(int bankAccountId, int amount)
    {
        foreach (BankAccount account in _accounts.Where(account => account.BankAccountId == bankAccountId))
            account.Amount += amount;
        return true;
    }
}
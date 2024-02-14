using System.Collections.Generic;
using Lab5.Application.Models.BankAccount;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankAccountRepository
{
    public IEnumerable<BankAccount> FindBankAccountsByUserId(int userId);
    public BankAccount? FindBankAccountByAccountId(int bankAccountId);
    public bool CreateAccount(int bankAccountId, int userId, int amount);
    public bool ChangeAmountAccount(int bankAccountId, int amount);
}
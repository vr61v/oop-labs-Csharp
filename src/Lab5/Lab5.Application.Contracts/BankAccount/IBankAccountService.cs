using System.Collections.Generic;

namespace Lab5.Application.Contracts.BankAccount;

public interface IBankAccountService
{
    public IEnumerable<Models.BankAccount.BankAccount> GetAllAccounts(int userId);
    public CreateResult CreateAccount(int userId);
    public OperationResult RefillAccount(int bankAccountId, int amount);
    public OperationResult WithdrawalAccount(int bankAccountId, int amount);
}
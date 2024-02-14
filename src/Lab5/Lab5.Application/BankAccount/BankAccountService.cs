using System.Collections.Generic;
using System.Security.Cryptography;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.BankAccount;

namespace Lab5.Application.BankAccount;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _repository;

    public BankAccountService(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Models.BankAccount.BankAccount> GetAllAccounts(int userId)
    {
        return _repository.FindBankAccountsByUserId(userId);
    }

    public CreateResult CreateAccount(int userId)
    {
        const int amount = 0;
        int bankAccountId = RandomNumberGenerator.GetInt32(int.MaxValue);
        return _repository.CreateAccount(bankAccountId, userId, amount) ? CreateResult.Success : CreateResult.NotCreate;
    }

    public OperationResult RefillAccount(int bankAccountId, int amount)
    {
        Models.BankAccount.BankAccount? bankAccount = _repository.FindBankAccountByAccountId(bankAccountId);
        if (bankAccount is null) return OperationResult.NotFound;
        return _repository.ChangeAmountAccount(bankAccountId, amount) ? OperationResult.Success : OperationResult.OperationFail;
    }

    public OperationResult WithdrawalAccount(int bankAccountId, int amount)
    {
        Models.BankAccount.BankAccount? bankAccount = _repository.FindBankAccountByAccountId(bankAccountId);
        if (bankAccount is null) return OperationResult.NotFound;
        if (bankAccount.Amount - amount < 0) return OperationResult.NotEnoughMoney;
        return _repository.ChangeAmountAccount(bankAccountId, -amount) ? OperationResult.Success : OperationResult.OperationFail;
    }
}
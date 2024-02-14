using System.Collections.Generic;
using System.Security.Cryptography;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.BankAccountOperations;

namespace Lab5.Application.BankAccountOperation;

public class BankAccountOperationsService : IBankAccountOperationsService
{
    private readonly IBankAccountOperationRepository _repository;

    public BankAccountOperationsService(IBankAccountOperationRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Models.BankAccountOperation.BankAccountOperation> GetOperations(int bankAccountId)
    {
        return _repository.FindOperationsByBankAccountId(bankAccountId);
    }

    public AddOperationResult AddOperation(int bankAccountId, string? typeOperation, int amount)
    {
        if (typeOperation is null) return AddOperationResult.NotAdd;
        int operationId = RandomNumberGenerator.GetInt32(int.MaxValue);
        return _repository.AddOperation(operationId, bankAccountId, typeOperation, amount) ? AddOperationResult.Success : AddOperationResult.NotAdd;
    }
}
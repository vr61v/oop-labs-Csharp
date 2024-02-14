using System.Collections.Generic;
using Lab5.Application.Models.BankAccountOperation;

namespace Lab5.Application.Abstractions.Repositories;

public interface IBankAccountOperationRepository
{
    public IEnumerable<BankAccountOperation> FindOperationsByBankAccountId(int bankAccountId);
    public bool AddOperation(int operationId, int bankAccountId, string typeOperation, int amount);
}
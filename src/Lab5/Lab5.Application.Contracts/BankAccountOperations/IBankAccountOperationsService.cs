using System.Collections.Generic;
using Lab5.Application.Models.BankAccountOperation;

namespace Lab5.Application.Contracts.BankAccountOperations;

public interface IBankAccountOperationsService
{
    public IEnumerable<BankAccountOperation> GetOperations(int bankAccountId);
}
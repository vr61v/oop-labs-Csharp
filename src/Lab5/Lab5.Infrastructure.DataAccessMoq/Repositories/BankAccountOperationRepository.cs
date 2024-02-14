using System.Collections.Generic;
using System.Linq;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.BankAccountOperation;

namespace Lab5.Infrastructure.DataAccessMoq.Repositories;

public class BankAccountOperationRepository : IBankAccountOperationRepository
{
    private List<BankAccountOperation> _operations = new List<BankAccountOperation>();

    public IEnumerable<BankAccountOperation> FindOperationsByBankAccountId(int bankAccountId)
    {
        return _operations.Where(x => x.BankAccountId == bankAccountId);
    }

    public bool AddOperation(int operationId, int bankAccountId, string typeOperation, int amount)
    {
        _operations.Add(new BankAccountOperation(operationId, bankAccountId, typeOperation, amount));
        return true;
    }
}
using System;

namespace Lab5.Application.Models.BankAccountOperation;

public class BankAccountOperation
{
    public BankAccountOperation(int operationId, int bankAccountId, string typeOperation, int amount)
    {
        OperationId = operationId;
        BankAccountId = bankAccountId;
        TypeOperation = (TypeOperation)Enum.Parse(typeof(TypeOperation), typeOperation);
        Amount = amount;
    }

    public BankAccountOperation(int operationId, int bankAccountId, TypeOperation typeOperation, int amount)
    {
        OperationId = operationId;
        BankAccountId = bankAccountId;
        TypeOperation = typeOperation;
        Amount = amount;
    }

    public int OperationId { get; private set; }
    public int BankAccountId { get; private set; }
    public TypeOperation TypeOperation { get; private set; }
    public int Amount { get; private set; }
}
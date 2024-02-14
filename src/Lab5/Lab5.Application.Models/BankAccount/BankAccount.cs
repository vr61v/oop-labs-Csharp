namespace Lab5.Application.Models.BankAccount;

public class BankAccount
{
    public BankAccount(int bankAccountId, int userId, int amount)
    {
        BankAccountId = bankAccountId;
        UserId = userId;
        Amount = amount;
    }

    public int BankAccountId { get; private set; }
    public int UserId { get; private set; }
    public int Amount { get; set; }
}
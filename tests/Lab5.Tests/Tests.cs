using System;
using System.Linq;
using Lab5.Application.BankAccount;

// using Lab5.Application.BankAccountOperation;
using Lab5.Application.Models.BankAccount;
using Lab5.Application.User;
using Lab5.Infrastructure.DataAccessMoq.Repositories;

// using Lab5.Presentation.Console;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void RefillWithdrawBankAccount()
    {
        var users = new UsersRepository();
        var accounts = new BankAccountRepository();

        var userService = new UserService(users, null);
        var accountService = new BankAccountService(accounts);

        const int cashRefill = 1500;
        const int cashWithdraw = 500;
        const string login = "Vr61v";
        const string password = "Vr61v's Password";
        const string? userTypeAccount = "User";
        int userId = $"{login}{password}".GetHashCode(StringComparison.CurrentCulture);

        userService.SignUp(login, password, userTypeAccount);
        accountService.CreateAccount(userId);
        BankAccount userAccount = accountService.GetAllAccounts(userId).First();
        accountService.RefillAccount(userAccount.BankAccountId, cashRefill);
        Assert.Equal(cashRefill, accountService.GetAllAccounts(userId).First().Amount);
        accountService.WithdrawalAccount(userAccount.BankAccountId, cashWithdraw);
        Assert.Equal(cashRefill - cashWithdraw, accountService.GetAllAccounts(userId).First().Amount);
    }

    // [Fact]
    // public void ConsolePresentation()
    // {
    //     var users = new UsersRepository();
    //     var accounts = new BankAccountRepository();
    //     var operations = new BankAccountOperationRepository();
    //
    //     var userService = new UserService(users, null);
    //     var accountService = new BankAccountService(accounts);
    //     var operationService = new BankAccountOperationsService(operations);
    //
    //     new ScenarioRunner(userService, accountService, operationService).Run();
    // }
}
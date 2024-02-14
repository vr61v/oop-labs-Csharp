using System.Collections.Generic;
using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class UserPageScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public UserPageScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "UserPage";
    public void Run()
    {
        if (_userService.CurrentUser is null)
        {
            AnsiConsole.Markup("[red]You have not logged in to the bank![/]\n");
            AnsiConsole.Ask<string>("[silver]Press any key to continue[/]");
            return;
        }

        bool isExit = false;
        while (!isExit)
        {
            AnsiConsole.Markup($"[lime]Login success.[/] Hello, {_userService.CurrentUser.Login}!\n");

            string command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new List<string>()
                {
                    "Your bank accounts", "back",
                }));
            switch (command)
            {
                case "Your bank accounts":
                    new BankAccountsScenario(_userService, _bankAccountService, _accountOperations).Run();
                    break;
                case "back":
                    isExit = true;
                    break;
            }

            AnsiConsole.Clear();
        }
    }
}
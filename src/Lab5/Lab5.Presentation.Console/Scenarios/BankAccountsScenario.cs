using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.Contracts.BankAccount;
using Lab5.Application.Models.BankAccount;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class BankAccountsScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public BankAccountsScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "BankAccounts";
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
            AnsiConsole.Markup("Your bank accounts:\n");
            var bankAccounts = _bankAccountService.GetAllAccounts(_userService.CurrentUser.UserId).ToList();

            var table = new Table();
            table.AddColumn("Bank account id");
            table.AddColumn("Amount");
            foreach (BankAccount account in bankAccounts)
            {
                table.AddRow(
                    account.BankAccountId.ToString(CultureInfo.InvariantCulture),
                    account.Amount.ToString(CultureInfo.InvariantCulture));
            }

            AnsiConsole.Write(table);

            string command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new List<string>()
                {
                    "Create new account", "Select account", "back",
                }));
            switch (command)
            {
                case "Create new account":
                {
                    CreateResult result = _bankAccountService.CreateAccount(_userService.CurrentUser.UserId);
                    if (result is CreateResult.Success)
                        AnsiConsole.Markup("[green]The account has been successfully created![/]\n");
                    else if (result is CreateResult.NotCreate)
                        AnsiConsole.Markup("[red]The account has not been created[/]\n");
                    AnsiConsole.Ask<string>("[silver]Press any key to continue[/]");
                    break;
                }

                case "Select account":
                {
                    string selectedId = AnsiConsole.Ask<string>("[white]Bank account id:[/] ");
                    int selected = int.Parse(selectedId, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    new OperationBankAccountScenario(_userService, _bankAccountService, _accountOperations, selected).Run();
                    break;
                }

                case "back":
                    isExit = true;
                    break;
            }

            AnsiConsole.Clear();
        }
    }
}
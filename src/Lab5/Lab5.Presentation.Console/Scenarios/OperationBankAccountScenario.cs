using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.Contracts.BankAccount;
using Lab5.Application.Models.BankAccountOperation;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class OperationBankAccountScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;
    private int _selectedId;

    public OperationBankAccountScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations, int selectedId)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
        _selectedId = selectedId;
    }

    public string Name => "OperationBankAccount";
    public void Run()
    {
        bool isExit = false;

        while (!isExit)
        {
            AnsiConsole.Markup($"Bank account {_selectedId}:\n");
            string command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .PageSize(4)
                .AddChoices(new List<string>()
                {
                    "Refill", "Withdrawal", "Draw all operations", "back",
                }));

            switch (command)
            {
                case "Refill":
                {
                    string amountString = AnsiConsole.Ask<string>("[white]Amount refill:[/] ");
                    int amount = int.Parse(amountString, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    OperationResult result = _bankAccountService.RefillAccount(_selectedId, amount);
                    if (result == OperationResult.Success)
                        _accountOperations.AddOperation(_selectedId, "Refill", amount);
                    break;
                }

                case "Withdrawal":
                {
                    string amountString = AnsiConsole.Ask<string>("[white]Amount withdrawal:[/] ");
                    int amount = int.Parse(amountString, NumberStyles.Integer, CultureInfo.InvariantCulture);
                    OperationResult result = _bankAccountService.WithdrawalAccount(_selectedId, amount);
                    if (result == OperationResult.Success)
                        _accountOperations.AddOperation(_selectedId, "Withdrawal", -amount);
                    break;
                }

                case "Draw all operations":
                {
                    var operations = _accountOperations.GetOperations(_selectedId).ToList();
                    var table = new Table();
                    table.AddColumn("Operation");
                    table.AddColumn("Amount");
                    foreach (BankAccountOperation operation in operations)
                    {
                        table.AddRow(
                            operation.TypeOperation.ToString(),
                            operation.Amount.ToString(CultureInfo.InvariantCulture));
                    }

                    AnsiConsole.Write(table);
                    AnsiConsole.Ask<string>("[white]Press any key to continue:[/] ");
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
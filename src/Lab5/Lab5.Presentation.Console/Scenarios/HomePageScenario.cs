using System.Collections.Generic;
using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class HomePageScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public HomePageScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "HomePage";
    public void Run()
    {
        bool isExit = false;
        while (!isExit)
        {
            string command = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Hello! Login or create new account.")
                .PageSize(3)
                .AddChoices(new List<string>()
                {
                    "Login", "SignUp", "Exit",
                }));
            switch (command)
            {
                case "Login":
                    new LoginScenario(_userService, _bankAccountService, _accountOperations).Run();
                    break;
                case "SignUp":
                    new SignUpScenario(_userService, _bankAccountService, _accountOperations).Run();
                    break;
                case "Exit":
                    isExit = true;
                    break;
            }

            AnsiConsole.Clear();
        }
    }
}
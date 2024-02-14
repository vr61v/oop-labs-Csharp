using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.Contracts.User;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class LoginScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public LoginScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "Login";
    public void Run()
    {
        bool isExit = false;
        while (!isExit)
        {
            string login = AnsiConsole.Ask<string>("[white]Login:[/] ");
            string password = AnsiConsole.Ask<string>("[white]Password:[/] ");

            LoginResult result = _userService.Login(login, password);
            switch (result)
            {
                case LoginResult.Success:
                    new UserPageScenario(_userService, _bankAccountService, _accountOperations).Run();
                    isExit = true;
                    break;
                case LoginResult.NotFound:
                    AnsiConsole.Markup("[red]The account was not found! Try again[/]\n");
                    AnsiConsole.Ask<string>("[silver]Press any key to continue[/]");
                    break;
            }

            AnsiConsole.Clear();
        }
    }
}
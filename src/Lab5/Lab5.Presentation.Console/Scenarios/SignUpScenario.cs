using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.Contracts.User;
using Lab5.Application.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios;

public class SignUpScenario : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public SignUpScenario(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "SignUp";
    public void Run()
    {
        bool isExit = false;
        while (!isExit)
        {
            string login = AnsiConsole.Ask<string>("[white]Login:[/] ");
            string password = AnsiConsole.Ask<string>("[white]Password:[/] ");
            string typeAccount = AnsiConsole.Ask<string>("[silver]Type account:[/] ");

            SignUpResult result = _userService.SignUp(login, password, typeAccount);
            switch (result)
            {
                case SignUpResult.Success:
                    new UserPageScenario(_userService, _bankAccountService, _accountOperations).Run();
                    isExit = true;
                    break;
                case SignUpResult.AlreadyCreated:
                    AnsiConsole.Ask<string>("[red]The account was already created! Try again[/]\n");
                    break;
                case SignUpResult.NotCreate:
                    AnsiConsole.Ask<string>("[red]The account was not created! Try again[/]\n");
                    break;
            }

            AnsiConsole.Clear();
        }
    }
}
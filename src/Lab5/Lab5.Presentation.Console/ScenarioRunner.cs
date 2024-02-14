using Lab5.Application.BankAccount;
using Lab5.Application.BankAccountOperation;
using Lab5.Application.User;
using Lab5.Presentation.Console.Scenarios;

namespace Lab5.Presentation.Console;

public class ScenarioRunner : IScenario
{
    private UserService _userService;
    private BankAccountService _bankAccountService;
    private BankAccountOperationsService _accountOperations;

    public ScenarioRunner(UserService userService, BankAccountService bankAccountService, BankAccountOperationsService accountOperations)
    {
        _userService = userService;
        _bankAccountService = bankAccountService;
        _accountOperations = accountOperations;
    }

    public string Name => "Runner";
    public void Run()
    {
        new HomePageScenario(_userService, _bankAccountService, _accountOperations).Run();
    }
}
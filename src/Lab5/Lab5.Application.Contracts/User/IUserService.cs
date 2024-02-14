namespace Lab5.Application.Contracts.User;

public interface IUserService
{
    public LoginResult Login(string? login, string? password);
    public SignUpResult SignUp(string? login, string? password, string? typeAccount);
}
using System;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models.User;

namespace Lab5.Application.User;

public class UserService : IUserService
{
    private readonly IUsersRepository _repository;

    public UserService(IUsersRepository repository, Models.User.User? currentUser)
    {
        _repository = repository;
        CurrentUser = currentUser;
    }

    public Models.User.User? CurrentUser { get; protected set; }

    public LoginResult Login(string? login, string? password)
    {
        if (login is null || password is null) return LoginResult.NotFound;

        int userId = $"{login}{password}".GetHashCode(StringComparison.CurrentCulture);
        Models.User.User? user = _repository.FindUserByUserId(userId);
        CurrentUser = user;
        return user is null ? LoginResult.NotFound : LoginResult.Success;
    }

    public SignUpResult SignUp(string? login, string? password, string? typeAccount)
    {
        if (login is null || password is null || typeAccount is null) return SignUpResult.NotCreate;

        int userId = $"{login}{password}".GetHashCode(StringComparison.CurrentCulture);
        var typeAccountParse = (TypeAccount)Enum.Parse(typeof(TypeAccount), typeAccount);

        if (_repository.FindUserByUserId(userId) is not null) return SignUpResult.AlreadyCreated;

        if (!_repository.CreateUser(userId, login, password, typeAccountParse)) return SignUpResult.NotCreate;
        CurrentUser = new Models.User.User(userId, login, password, typeAccountParse);
        return SignUpResult.Success;
    }

    public Models.User.User? GetUser(string? login)
    {
        if (CurrentUser?.TypeAccount is not TypeAccount.Admin || login is null) return null;
        return _repository.FindUserByLogin(login);
    }
}
using System;

namespace Lab5.Application.Models.User;

public class User
{
    public User(int userId, string login, string password, string typeAccount)
    {
        UserId = userId;
        TypeAccount = (TypeAccount)Enum.Parse(typeof(TypeAccount), typeAccount);
        Login = login;
        Password = password;
    }

    public User(int userId, string login, string password, TypeAccount typeAccount)
    {
        UserId = userId;
        TypeAccount = typeAccount;
        Login = login;
        Password = password;
    }

    public int UserId { get; private set; }
    public string Login { get; private set; }
    public string Password { get; private set; }
    public TypeAccount TypeAccount { get; private set; }
}
using System.Collections.Generic;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.User;

namespace Lab5.Infrastructure.DataAccessMoq.Repositories;

public class UsersRepository : IUsersRepository
{
    private List<User> _users = new List<User>();

    public User? FindUserByUserId(int userId)
    {
        return _users.Find(x => x.UserId == userId);
    }

    public User? FindUserByLogin(string login)
    {
        return _users.Find(x => x.Login == login);
    }

    public bool CreateUser(int userId, string login, string password, TypeAccount typeAccount)
    {
        _users.Add(new User(userId, login, password, typeAccount));
        return true;
    }
}
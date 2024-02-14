using Lab5.Application.Models.User;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUsersRepository
{
    public User? FindUserByUserId(int userId);
    public User? FindUserByLogin(string login);

    public bool CreateUser(int userId, string login, string password, TypeAccount typeAccount);
}
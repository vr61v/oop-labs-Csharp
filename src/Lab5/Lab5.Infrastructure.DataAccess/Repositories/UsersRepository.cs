using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.User;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UsersRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUserId(int userId)
    {
        const string sql = "select UserID, Login, Password, UserTypeAccount from Users";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return null;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (reader.GetInt32(0) == userId)
                return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
        }

        return null;
    }

    public User? FindUserByLogin(string login)
    {
        const string sql = "select UserID, Login, Password, UserTypeAccount from Users";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return null;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (reader.GetString(1) == login)
                return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
        }

        return null;
    }

    public bool CreateUser(int userId, string login, string password, TypeAccount typeAccount)
    {
        const string sql = "insert into Users (UserID, Login, Password, UserTypeAccount) values (@userId, @login, @password, @typeAccount)";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return false;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@userId", userId);
        command.AddParameter("@login", login);
        command.AddParameter("@password", password);
        command.AddParameter("@typeAccount", typeAccount);

        return true;
    }
}
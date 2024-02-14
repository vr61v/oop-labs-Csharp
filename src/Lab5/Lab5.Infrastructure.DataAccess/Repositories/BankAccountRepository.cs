using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.BankAccount;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankAccount> FindBankAccountsByUserId(int userId)
    {
        const string sql = "select BankAccountID, UserID, Amount from BankAccounts";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return new List<BankAccount>();
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        var accounts = new List<BankAccount>();
        while (reader.Read())
        {
            if (reader.GetInt32(1) == userId)
            {
                accounts.Add(new BankAccount(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)));
            }
        }

        return accounts;
    }

    public BankAccount? FindBankAccountByAccountId(int bankAccountId)
    {
        const string sql = "select BankAccountID, UserID, Amount from BankAccounts";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return null;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (reader.GetInt32(1) == bankAccountId)
            {
                return new BankAccount(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2));
            }
        }

        return null;
    }

    public bool CreateAccount(int bankAccountId, int userId, int amount)
    {
        const string sql = "insert into BankAccounts (BankAccountID, UserID, Amount) values (@bankAccountId, @userId, @amount)";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return false;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@bankAccountId", bankAccountId);
        command.AddParameter("@userId", userId);
        command.AddParameter("@amount", amount);

        return true;
    }

    public bool ChangeAmountAccount(int bankAccountId, int amount)
    {
        const string sql = "update BankAccounts set Amount = Amount + @amount where BankAccountID = @bankAccountId";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return false;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@bankAccountId", bankAccountId);
        command.AddParameter("@amount", amount);

        return true;
    }
}
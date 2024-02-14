using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.BankAccountOperation;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class BankAccountOperationRepository : IBankAccountOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountOperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankAccountOperation> FindOperationsByBankAccountId(int bankAccountId)
    {
        const string sql = "select OperationID, BankAccountID, Operation, Amount from BankAccountOperations";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return new List<BankAccountOperation>();
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        var operations = new List<BankAccountOperation>();
        while (reader.Read())
        {
            if (reader.GetInt32(1) == bankAccountId)
            {
                operations.Add(new BankAccountOperation(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetInt32(3)));
            }
        }

        return operations;
    }

    public bool AddOperation(int operationId, int bankAccountId, string typeOperation, int amount)
    {
        const string sql = "insert into BankAccountOperations (OperationID, BankAccountID, Operation, Amount) values (@operationID, @bankAccountID, @operation, @amount)";

        ValueTask<NpgsqlConnection> connectionAsync = _connectionProvider.GetConnectionAsync(default);
        if (!connectionAsync.IsCompleted) return false;
        NpgsqlConnection connection = connectionAsync.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@operationId", operationId);
        command.AddParameter("@bankAccountId", bankAccountId);
        command.AddParameter("@typeOperation", typeOperation);
        command.AddParameter("@amount", amount);

        return true;
    }
}
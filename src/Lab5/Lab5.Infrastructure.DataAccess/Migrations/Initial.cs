using FluentMigrator;

namespace Lab5.Infrastructure.DataAccess.Migrations;

public class Initial : Migration
{
    public override void Up()
    {
        if (!Schema.Table("Users").Exists())
        {
            Create.Table("Users")
                .WithColumn("UserID").AsInt32().NotNullable()
                .WithColumn("Login").AsAnsiString(30).NotNullable()
                .WithColumn("Password").AsAnsiString(30).NotNullable()
                .WithColumn("UserTypeAccount").AsAnsiString(30).NotNullable();
        }

        if (!Schema.Table("BankAccounts").Exists())
        {
            Create.Table("BankAccounts")
                .WithColumn("BankAccountID").AsInt32().NotNullable()
                .WithColumn("UserID").AsInt32().NotNullable()
                .WithColumn("Amount").AsInt32();
        }

        if (!Schema.Table("BankAccountOperations").Exists())
        {
            Create.Table("BankAccountOperations")
                .WithColumn("OperationID").AsInt32().NotNullable()
                .WithColumn("BankAccountID").AsInt32().NotNullable()
                .WithColumn("Operation").AsAnsiString(30).NotNullable()
                .WithColumn("Amount").AsInt32().NotNullable();
        }
    }

    public override void Down()
    {
        if (!Schema.Table("Users").Exists())
        {
            Delete.Table("Users");
        }

        if (!Schema.Table("BankAccounts").Exists())
        {
            Delete.Table("BankAccounts");
        }

        if (!Schema.Table("BankAccountOperations").Exists())
        {
            Delete.Table("BankAccountOperations");
        }
    }
}
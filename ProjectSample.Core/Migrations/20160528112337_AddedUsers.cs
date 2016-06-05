using System;
using System.Collections.Generic;
using FluentMigrator;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Migrations
{
    [Migration(6)]
    public class AddedUsers : Migration
    {
        public override void Up()
        {

            // Table: Customer.
            Alter.Table("Customer").InSchema("dbo").AddColumn("UserId").AsGuid().Nullable();

            // Table: Role.
            Create.Table("Role").InSchema("dbo").WithColumn("RoleId").AsInt32().PrimaryKey().NotNullable()
            .WithColumn("Name").AsString(255).Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable();
            var roles = new List<Role>
            {
                            Role.User,
                            Role.Administrator
                        };

            foreach (var role in roles)
            {
                Insert.IntoTable("Role")
                    .InSchema("dbo")
                    .Row(new { RoleId = role.Id, role.Name, LastModified = DateTime.Now });
            }
            // Table: User.
            Create.Table("User").InSchema("dbo").WithColumn("UserId").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Version").AsInt32().NotNullable()
            .WithColumn("UserName").AsString(255).Nullable()
            .WithColumn("PasswordHash").AsString(255).Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("CustomerId").AsInt64().Nullable()
            .WithColumn("RoleId").AsInt32().Nullable();

            // Foreign keys for table: Customer.
            Create.ForeignKey("FKFE9A39C026EDEAE1").FromTable("Customer").InSchema("dbo").ForeignColumns("UserId").ToTable("User").InSchema("dbo").PrimaryColumns("UserId");

            // Foreign keys for table: User.
            Create.ForeignKey("FK7185C17CFC8F1F3").FromTable("User").InSchema("dbo").ForeignColumns("CustomerId").ToTable("Customer").InSchema("dbo").PrimaryColumns("CustomerId");
            Create.ForeignKey("FK7185C17C81E2A349").FromTable("User").InSchema("dbo").ForeignColumns("RoleId").ToTable("Role").InSchema("dbo").PrimaryColumns("RoleId");


        }

        public override void Down()
        {

            // Foreign keys for table: Customer.
            Delete.ForeignKey("FKFE9A39C026EDEAE1").OnTable("Customer").InSchema("dbo");

            // Foreign keys for table: User.
            Delete.ForeignKey("FK7185C17CFC8F1F3").OnTable("User").InSchema("dbo");
            Delete.ForeignKey("FK7185C17C81E2A349").OnTable("User").InSchema("dbo");

            // Table: Customer.
            Delete.Column("UserId").FromTable("Customer").InSchema("dbo");

            // Tabela: Role.
            Delete.Table("Role").InSchema("dbo");

            // Tabela: User.
            Delete.Table("User").InSchema("dbo");

        }
    }
}

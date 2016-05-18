using System;
using System.Collections.Generic;
using System.IO;
using FluentMigrator;
using ProjectSample.Core.Domain;

namespace ProjectSample.Migrations
{
    [Migration(1)]
    public class CreateOrderStateHistory : Migration
    {
        public override void Up()
        {

            // Table: Order.
            Create.Table("Order").InSchema("").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("CurrentStateId").AsInt16().Nullable();

            // Table: OrderState.
            Create.Table("OrderState").InSchema("").WithColumn("Id").AsInt16().PrimaryKey().NotNullable()
            .WithColumn("Name").AsString(255).Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable();

            // Table: OrderStateHistoryItem.
            Create.Table("OrderStateHistoryItem").InSchema("").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Created").AsDateTime().Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("OrderId").AsInt64().Nullable()
            .WithColumn("StateId").AsInt16().Nullable();

            // Foreign keys for table: Order.
            Create.ForeignKey("FK3117099BF33F4407").FromTable("Order").InSchema("").ForeignColumns("CurrentStateId").ToTable("OrderState").InSchema("").PrimaryColumns("Id");

            // Foreign keys for table: OrderStateHistoryItem.
            Create.ForeignKey("FKEBAAA11E871A04D2").FromTable("OrderStateHistoryItem").InSchema("").ForeignColumns("OrderId").ToTable("Order").InSchema("").PrimaryColumns("Id");
            Create.ForeignKey("FKEBAAA11E3CAD2FD").FromTable("OrderStateHistoryItem").InSchema("").ForeignColumns("StateId").ToTable("OrderState").InSchema("").PrimaryColumns("Id");

            var objs = new List<OrderState>()
            {
                OrderState.Accepted,
                OrderState.Completed,
                OrderState.Placed
            };

            foreach (var state in objs)
            {
                Insert.IntoTable("OrderState").Row(state);
            }
        }

        public override void Down()
        {

            // Foreign keys for table: Order.
            Delete.ForeignKey("FK3117099BF33F4407").OnTable("Order").InSchema("");

            // Foreign keys for table: OrderStateHistoryItem.
            Delete.ForeignKey("FKEBAAA11E871A04D2").OnTable("OrderStateHistoryItem").InSchema("");
            Delete.ForeignKey("FKEBAAA11E3CAD2FD").OnTable("OrderStateHistoryItem").InSchema("");

            // Tabela: Order.
            Delete.Table("Order").InSchema("");

            // Tabela: OrderState.
            Delete.Table("OrderState").InSchema("");

            // Tabela: OrderStateHistoryItem.
            Delete.Table("OrderStateHistoryItem").InSchema("");

        }
    }
}

using System.Collections.Generic;
using FluentMigrator;
using ProjectSample.Core.Domain;

namespace ProjectSample.Core.Migrations
{
    [Migration(1)]
    public class CreateOrderStateHistory : Migration
    {
        public override void Up()
        {
            // Table: Order.
            Create.Table("Order").InSchema("dbo").WithColumn("OrderId").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("LastModified").AsDateTime().Nullable()
                .WithColumn("CurrentStateId").AsInt16().Nullable();

            // Table: OrderState.
            Create.Table("OrderState").InSchema("dbo").WithColumn("OrderStateId").AsInt16().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("LastModified").AsDateTime().Nullable();

            // Table: OrderStateHistoryItem.
            Create.Table("OrderStateHistoryItem")
                .InSchema("dbo")
                .WithColumn("OrderStateHistoryItemId")
                .AsInt64()
                .PrimaryKey()
                .Identity()
                .NotNullable()
                .WithColumn("Created").AsDateTime().Nullable()
                .WithColumn("LastModified").AsDateTime().Nullable()
                .WithColumn("OrderId").AsInt64().Nullable()
                .WithColumn("StateId").AsInt16().Nullable();

            // Foreign keys for table: Order.
            Create.ForeignKey("FK3117099BF33F4407")
                .FromTable("Order")
                .InSchema("dbo")
                .ForeignColumns("CurrentStateId")
                .ToTable("OrderState")
                .InSchema("dbo")
                .PrimaryColumns("OrderStateId");

            // Foreign keys for table: OrderStateHistoryItem.
            Create.ForeignKey("FKEBAAA11E871A04D2")
                .FromTable("OrderStateHistoryItem")
                .InSchema("dbo")
                .ForeignColumns("OrderId")
                .ToTable("Order")
                .InSchema("dbo")
                .PrimaryColumns("OrderId");
            Create.ForeignKey("FKEBAAA11E3CAD2FD")
                .FromTable("OrderStateHistoryItem")
                .InSchema("dbo")
                .ForeignColumns("StateId")
                .ToTable("OrderState")
                .InSchema("dbo")
                .PrimaryColumns("OrderStateId");

            var objs = new List<OrderState>
            {
                OrderState.Accepted,
                OrderState.Completed,
                OrderState.Placed
            };

            foreach (var state in objs)
            {
                Insert.IntoTable("OrderState").Row(new {OrderStateId = state.Id, state.Name, state.LastModified});
            }
        }

        public override void Down()
        {
            // Foreign keys for table: Order.
            Delete.ForeignKey("FK3117099BF33F4407").OnTable("Order").InSchema("dbo");

            // Foreign keys for table: OrderStateHistoryItem.
            Delete.ForeignKey("FKEBAAA11E871A04D2").OnTable("OrderStateHistoryItem").InSchema("dbo");
            Delete.ForeignKey("FKEBAAA11E3CAD2FD").OnTable("OrderStateHistoryItem").InSchema("dbo");

            // Tabela: Order.
            Delete.Table("Order").InSchema("dbo");

            // Tabela: OrderState.
            Delete.Table("OrderState").InSchema("dbo");

            // Tabela: OrderStateHistoryItem.
            Delete.Table("OrderStateHistoryItem").InSchema("dbo");
        }
    }
}
using FluentMigrator;

namespace ProjectSample.Core.Migrations
{
    [Migration(5)]
    public class AddedBasket : Migration
    {
        public override void Up()
        {
            // Table: Basket.
            Create.Table("Basket")
                .InSchema("dbo")
                .WithColumn("BasketId")
                .AsInt64()
                .PrimaryKey()
                .Identity()
                .NotNullable()
                .WithColumn("LastModified").AsDateTime().Nullable()
                .WithColumn("CustomerId").AsInt64().Nullable();

            // Table: BasketItem.
            Create.Table("BasketItem")
                .InSchema("dbo")
                .WithColumn("BasketItemId")
                .AsInt64()
                .PrimaryKey()
                .Identity()
                .NotNullable()
                .WithColumn("Quantity").AsInt32().Nullable()
                .WithColumn("LastModified").AsDateTime().Nullable()
                .WithColumn("ProductId").AsInt64().Nullable()
                .WithColumn("BasketId").AsInt64().Nullable();

            // Table: Customer.
            Create.Table("Customer")
                .InSchema("dbo")
                .WithColumn("CustomerId")
                .AsInt64()
                .PrimaryKey()
                .Identity()
                .NotNullable()
                .WithColumn("Identifier").AsString(255).Nullable()
                .WithColumn("LastModified").AsDateTime().Nullable();

            // Foreign keys for table: Basket.
            Create.ForeignKey("FKD4474AC2FC8F1F3")
                .FromTable("Basket")
                .InSchema("dbo")
                .ForeignColumns("CustomerId")
                .ToTable("Customer")
                .InSchema("dbo")
                .PrimaryColumns("CustomerId");

            // Foreign keys for table: BasketItem.
            Create.ForeignKey("FK729387BD280DE5CE")
                .FromTable("BasketItem")
                .InSchema("dbo")
                .ForeignColumns("ProductId")
                .ToTable("Product")
                .InSchema("dbo")
                .PrimaryColumns("ProductId");
            Create.ForeignKey("FK729387BD1A53E8C5")
                .FromTable("BasketItem")
                .InSchema("dbo")
                .ForeignColumns("BasketId")
                .ToTable("Basket")
                .InSchema("dbo")
                .PrimaryColumns("BasketId");

            // Foreign keys for table: Order.
            Create.ForeignKey("FK3117099B6A32E7BA")
                .FromTable("Order")
                .InSchema("dbo")
                .ForeignColumns("CurrentStateId")
                .ToTable("OrderState")
                .InSchema("dbo")
                .PrimaryColumns("OrderStateId");

            // Foreign keys for table: OrderItem.
            Create.ForeignKey("FK3EF888582FF3506")
                .FromTable("OrderItem")
                .InSchema("dbo")
                .ForeignColumns("OrderId")
                .ToTable("Order")
                .InSchema("dbo")
                .PrimaryColumns("OrderId");
            Create.ForeignKey("FK3EF88858280DE5CE")
                .FromTable("OrderItem")
                .InSchema("dbo")
                .ForeignColumns("ProductId")
                .ToTable("Product")
                .InSchema("dbo")
                .PrimaryColumns("ProductId");

            // Foreign keys for table: OrderStateHistoryItem.
            Create.ForeignKey("FKEBAAA11E2FF3506")
                .FromTable("OrderStateHistoryItem")
                .InSchema("dbo")
                .ForeignColumns("OrderId")
                .ToTable("Order")
                .InSchema("dbo")
                .PrimaryColumns("OrderId");
            Create.ForeignKey("FKEBAAA11E62DE27A3")
                .FromTable("OrderStateHistoryItem")
                .InSchema("dbo")
                .ForeignColumns("StateId")
                .ToTable("OrderState")
                .InSchema("dbo")
                .PrimaryColumns("OrderStateId");

            // Foreign keys for table: Shipment.
            Create.ForeignKey("FK9E65A9592FF3506")
                .FromTable("Shipment")
                .InSchema("dbo")
                .ForeignColumns("OrderId")
                .ToTable("Order")
                .InSchema("dbo")
                .PrimaryColumns("OrderId");

            // Foreign keys for table: ShipmentItem.
            Create.ForeignKey("FKA7C3996E1B9CB5C6")
                .FromTable("ShipmentItem")
                .InSchema("dbo")
                .ForeignColumns("OrderItemId")
                .ToTable("OrderItem")
                .InSchema("dbo")
                .PrimaryColumns("OrderItemId");
            Create.ForeignKey("FKA7C3996E987D21B6")
                .FromTable("ShipmentItem")
                .InSchema("dbo")
                .ForeignColumns("ShipmentId")
                .ToTable("Shipment")
                .InSchema("dbo")
                .PrimaryColumns("ShipmentId");

            // Indexes for table: Shipment.
            Create.Index("IX_Shipment_Order_OrderId")
                .OnTable("Shipment")
                .InSchema("dbo")
                .OnColumn("OrderId")
                .Ascending();
        }

        public override void Down()
        {
            // Indexes for table: Shipment.
            Delete.Index("IX_Shipment_Order_OrderId").OnTable("Shipment").InSchema("dbo");

            // Foreign keys for table: Basket.
            Delete.ForeignKey("FKD4474AC2FC8F1F3").OnTable("Basket").InSchema("dbo");

            // Foreign keys for table: BasketItem.
            Delete.ForeignKey("FK729387BD280DE5CE").OnTable("BasketItem").InSchema("dbo");
            Delete.ForeignKey("FK729387BD1A53E8C5").OnTable("BasketItem").InSchema("dbo");

            // Foreign keys for table: Order.
            Delete.ForeignKey("FK3117099B6A32E7BA").OnTable("Order").InSchema("dbo");

            // Foreign keys for table: OrderItem.
            Delete.ForeignKey("FK3EF888582FF3506").OnTable("OrderItem").InSchema("dbo");
            Delete.ForeignKey("FK3EF88858280DE5CE").OnTable("OrderItem").InSchema("dbo");

            // Foreign keys for table: OrderStateHistoryItem.
            Delete.ForeignKey("FKEBAAA11E2FF3506").OnTable("OrderStateHistoryItem").InSchema("dbo");
            Delete.ForeignKey("FKEBAAA11E62DE27A3").OnTable("OrderStateHistoryItem").InSchema("dbo");

            // Foreign keys for table: Shipment.
            Delete.ForeignKey("FK9E65A9592FF3506").OnTable("Shipment").InSchema("dbo");

            // Foreign keys for table: ShipmentItem.
            Delete.ForeignKey("FKA7C3996E1B9CB5C6").OnTable("ShipmentItem").InSchema("dbo");
            Delete.ForeignKey("FKA7C3996E987D21B6").OnTable("ShipmentItem").InSchema("dbo");

            // Tabela: Basket.
            Delete.Table("Basket").InSchema("dbo");

            // Tabela: BasketItem.
            Delete.Table("BasketItem").InSchema("dbo");

            // Tabela: Customer.
            Delete.Table("Customer").InSchema("dbo");
        }
    }
}
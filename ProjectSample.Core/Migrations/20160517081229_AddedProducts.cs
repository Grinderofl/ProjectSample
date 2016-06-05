using System;
using FluentMigrator;

namespace ProjectSample.Core.Migrations
{
    [Migration(2)]
    public class AddedProducts : Migration
    {
        public override void Up()
        {

            // Table: Order.
            Alter.Table("Order").InSchema("dbo").AddColumn("Created").AsDateTime().Nullable();
            Update.Table("Order").InSchema("dbo").Set(new {Created = DateTime.Now}).AllRows();
            // Table: OrderItem.
            Create.Table("OrderItem").InSchema("dbo").WithColumn("OrderItemId").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Quantity").AsInt32().Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("OrderId").AsInt64().Nullable()
            .WithColumn("ProductId").AsInt64().Nullable();

            // Table: Product.
            Create.Table("Product").InSchema("dbo").WithColumn("ProductId").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(255).Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable();

            // Foreign keys for table: OrderItem.
            Create.ForeignKey("FK3EF88858871A04D2").FromTable("OrderItem").InSchema("dbo").ForeignColumns("OrderId").ToTable("Order").InSchema("dbo").PrimaryColumns("OrderId");
            Create.ForeignKey("FK3EF88858170B6747").FromTable("OrderItem").InSchema("dbo").ForeignColumns("ProductId").ToTable("Product").InSchema("dbo").PrimaryColumns("ProductId");


        }

        public override void Down()
        {

            // Foreign keys for table: OrderItem.
            Delete.ForeignKey("FK3EF88858871A04D2").OnTable("OrderItem").InSchema("dbo");
            Delete.ForeignKey("FK3EF88858170B6747").OnTable("OrderItem").InSchema("dbo");

            // Table: Order.
            Delete.Column("Created").FromTable("Order").InSchema("dbo");

            // Tabela: OrderItem.
            Delete.Table("OrderItem").InSchema("dbo");

            // Tabela: Product.
            Delete.Table("Product").InSchema("dbo");

        }
    }
}

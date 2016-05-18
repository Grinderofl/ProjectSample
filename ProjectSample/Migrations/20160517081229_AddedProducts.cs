using System;
using System.IO;
using FluentMigrator;

namespace ProjectSample.Migrations
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
            Create.Table("OrderItem").InSchema("dbo").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Quantity").AsInt32().Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("Order_id").AsInt64().Nullable()
            .WithColumn("Product_id").AsInt64().Nullable();

            // Table: Product.
            Create.Table("Product").InSchema("dbo").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(255).Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable();

            // Foreign keys for table: OrderItem.
            Create.ForeignKey("FK3EF88858871A04D2").FromTable("OrderItem").InSchema("dbo").ForeignColumns("Order_id").ToTable("Order").InSchema("dbo").PrimaryColumns("Id");
            Create.ForeignKey("FK3EF88858170B6747").FromTable("OrderItem").InSchema("dbo").ForeignColumns("Product_id").ToTable("Product").InSchema("dbo").PrimaryColumns("Id");


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

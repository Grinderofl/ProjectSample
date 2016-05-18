using System;
using System.IO;
using FluentMigrator;

namespace ProjectSample.Migrations
{
    [Migration(4)]
    public class AddedShipments : Migration
    {
        public override void Up()
        {

            // Table: Shipment.
            Create.Table("Shipment").InSchema("dbo").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("Order_id").AsInt64().Nullable();

            // Table: ShipmentItem.
            Create.Table("ShipmentItem").InSchema("dbo").WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
            .WithColumn("Quantity").AsInt32().Nullable()
            .WithColumn("LastModified").AsDateTime().Nullable()
            .WithColumn("Shipment_id").AsInt64().Nullable()
            .WithColumn("OrderItem_id").AsInt64().Nullable();

            // Foreign keys for table: Shipment.
            Create.ForeignKey("FK9E65A959871A04D2").FromTable("Shipment").InSchema("dbo").ForeignColumns("Order_id").ToTable("Order").InSchema("dbo").PrimaryColumns("Id");

            // Foreign keys for table: ShipmentItem.
            Create.ForeignKey("FKA7C3996E6373F36E").FromTable("ShipmentItem").InSchema("dbo").ForeignColumns("Shipment_id").ToTable("Shipment").InSchema("dbo").PrimaryColumns("Id");
            Create.ForeignKey("FKA7C3996E430F7AB8").FromTable("ShipmentItem").InSchema("dbo").ForeignColumns("OrderItem_id").ToTable("OrderItem").InSchema("dbo").PrimaryColumns("Id");


        }

        public override void Down()
        {

            // Foreign keys for table: Shipment.
            Delete.ForeignKey("FK9E65A959871A04D2").OnTable("Shipment").InSchema("dbo");

            // Foreign keys for table: ShipmentItem.
            Delete.ForeignKey("FKA7C3996E6373F36E").OnTable("ShipmentItem").InSchema("dbo");
            Delete.ForeignKey("FKA7C3996E430F7AB8").OnTable("ShipmentItem").InSchema("dbo");

            // Tabela: Shipment.
            Delete.Table("Shipment").InSchema("dbo");

            // Tabela: ShipmentItem.
            Delete.Table("ShipmentItem").InSchema("dbo");

        }
    }
}

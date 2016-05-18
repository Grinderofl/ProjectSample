using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentMigrator;

namespace ProjectSample.Migrations
{
    [Migration(3)]
    public class MadeCurrentStateNotNull : Migration
    {
        public override void Up()
        {
            Update.Table("Order").InSchema("dbo").Set(new {CurrentStateId = (int?)1}).Where(new {CurrentStateId = (int?)null});
            Alter.Table("Order").InSchema("dbo").AlterColumn("CurrentStateId").AsInt16().NotNullable();
        }

        public override void Down()
        {
            Alter.Table("Order").InSchema("dbo").AlterColumn("CurrentStateId").AsInt16().Nullable();
        }
    }
}
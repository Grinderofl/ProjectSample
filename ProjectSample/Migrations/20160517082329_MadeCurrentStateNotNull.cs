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
            Update.Table("Order").InSchema("dbo").Set(new {CurrentState_id = (int?)1}).Where(new {CurrentState_id = (int?)null});
            Alter.Table("Order").InSchema("dbo").AlterColumn("CurrentState_id").AsInt16().NotNullable();
        }

        public override void Down()
        {
            Alter.Table("Order").InSchema("dbo").AlterColumn("CurrentState_id").AsInt16().Nullable();
        }
    }
}
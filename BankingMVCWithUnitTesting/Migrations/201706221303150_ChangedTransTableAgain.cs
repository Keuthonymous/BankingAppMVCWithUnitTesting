namespace BankingMVCWithUnitTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTransTableAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trans", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Trans", "eventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trans", "eventType", c => c.Int(nullable: false));
            DropColumn("dbo.Trans", "Type");
        }
    }
}

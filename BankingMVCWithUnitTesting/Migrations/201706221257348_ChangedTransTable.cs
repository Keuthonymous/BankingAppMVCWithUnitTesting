namespace BankingMVCWithUnitTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTransTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trans", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trans", "Amount");
        }
    }
}

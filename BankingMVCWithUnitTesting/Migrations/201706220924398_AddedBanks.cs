namespace BankingMVCWithUnitTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBanks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BankName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BankCapital = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Accounts", "Balance", c => c.Double(nullable: false));
            AddColumn("dbo.Accounts", "BankID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "BankID");
            AddForeignKey("dbo.Accounts", "BankID", "dbo.Banks", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "BankID", "dbo.Banks");
            DropIndex("dbo.Accounts", new[] { "BankID" });
            DropColumn("dbo.Accounts", "BankID");
            DropColumn("dbo.Accounts", "Balance");
            DropTable("dbo.Banks");
        }
    }
}

namespace BankingMVCWithUnitTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrans : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountHolderFName = c.String(nullable: false),
                        AccountHolderLName = c.String(nullable: false),
                        SSN = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Balance = c.Double(nullable: false),
                        BankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Banks", t => t.BankID, cascadeDelete: true)
                .Index(t => t.BankID);
            
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
            
            CreateTable(
                "dbo.Trans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        eventType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransAccounts",
                c => new
                    {
                        Trans_ID = c.Int(nullable: false),
                        Account_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trans_ID, t.Account_ID })
                .ForeignKey("dbo.Trans", t => t.Trans_ID, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_ID, cascadeDelete: true)
                .Index(t => t.Trans_ID)
                .Index(t => t.Account_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransAccounts", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.TransAccounts", "Trans_ID", "dbo.Trans");
            DropForeignKey("dbo.Accounts", "BankID", "dbo.Banks");
            DropIndex("dbo.TransAccounts", new[] { "Account_ID" });
            DropIndex("dbo.TransAccounts", new[] { "Trans_ID" });
            DropIndex("dbo.Accounts", new[] { "BankID" });
            DropTable("dbo.TransAccounts");
            DropTable("dbo.Trans");
            DropTable("dbo.Banks");
            DropTable("dbo.Accounts");
        }
    }
}

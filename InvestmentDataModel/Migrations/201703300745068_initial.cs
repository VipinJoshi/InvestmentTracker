namespace InvestmentDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccountDetails",
                c => new
                    {
                        UserAccountDetailID = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(precision: 0),
                        PanCard = c.String(maxLength: 15, unicode: false),
                        EarningSlabID = c.Int(),
                        Gender = c.Boolean(),
                        MobileNumber = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.UserAccountDetailID)
                .ForeignKey("dbo.UserLogins", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Password = c.String(unicode: false),
                        Active = c.Boolean(nullable: false),
                        Locked = c.Boolean(nullable: false),
                        DateOfAccountCreation = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "User_UserName")
                .Index(t => t.Email, unique: true, name: "User_Email");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccountDetails", "UserId", "dbo.UserLogins");
            DropIndex("dbo.UserLogins", "User_Email");
            DropIndex("dbo.UserLogins", "User_UserName");
            DropIndex("dbo.UserAccountDetails", new[] { "UserId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserAccountDetails");
        }
    }
}

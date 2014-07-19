namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOnlineJudgeSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 300),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        CreateTS = c.DateTime(nullable: false),
                        UpdateTS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}

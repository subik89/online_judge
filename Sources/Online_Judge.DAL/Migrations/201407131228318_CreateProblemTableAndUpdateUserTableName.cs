namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProblemTableAndUpdateUserTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Users");
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 300),
                        Content = c.String(nullable: false, maxLength: 4000),
                        CreateTS = c.DateTime(nullable: false),
                        UpdateTS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProblemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Problems");
            RenameTable(name: "dbo.Users", newName: "User");
        }
    }
}

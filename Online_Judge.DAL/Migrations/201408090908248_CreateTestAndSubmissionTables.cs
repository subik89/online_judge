namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTestAndSubmissionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        ProblemID = c.Int(nullable: false),
                        Name = c.String(),
                        TimeLimit = c.Time(nullable: false, precision: 7),
                        CreateTS = c.DateTime(nullable: false),
                        UpdateTS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Problems", t => t.ProblemID, cascadeDelete: true)
                .Index(t => t.ProblemID);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        Language = c.String(),
                        Status = c.Int(nullable: false),
                        Code = c.String(),
                        CreateTS = c.DateTime(nullable: false),
                        UpdateTS = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionID)
                .ForeignKey("dbo.Problems", t => t.ProblemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ProblemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "UserID", "dbo.Users");
            DropForeignKey("dbo.Submissions", "ProblemID", "dbo.Problems");
            DropForeignKey("dbo.Tests", "ProblemID", "dbo.Problems");
            DropIndex("dbo.Submissions", new[] { "ProblemID" });
            DropIndex("dbo.Submissions", new[] { "UserID" });
            DropIndex("dbo.Tests", new[] { "ProblemID" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Tests");
        }
    }
}

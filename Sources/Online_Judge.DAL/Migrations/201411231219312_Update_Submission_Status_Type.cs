namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Submission_Status_Type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "Status", c => c.Int(nullable: false));
        }
    }
}

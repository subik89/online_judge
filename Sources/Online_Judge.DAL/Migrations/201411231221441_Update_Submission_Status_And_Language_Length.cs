namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Submission_Status_And_Language_Length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "Language", c => c.String(maxLength: 20));
            AlterColumn("dbo.Submissions", "Status", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "Status", c => c.String());
            AlterColumn("dbo.Submissions", "Language", c => c.String());
        }
    }
}

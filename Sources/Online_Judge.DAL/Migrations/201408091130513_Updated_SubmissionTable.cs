namespace Online_Judge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_SubmissionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "IsChecked");
        }
    }
}

namespace StudentSmartCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_card_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentCards", "ProcessedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCards", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCards", "StudentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentCards", "StudentId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StudentCards", "Amount", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.StudentCards", "ProcessedBy", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace StudentSmartCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_card : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardId = c.String(nullable: false, maxLength: 50),
                        ProcessedBy = c.String(nullable: false, maxLength: 50),
                        Amount = c.String(nullable: false, maxLength: 50),
                        StudentId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentCards");
        }
    }
}

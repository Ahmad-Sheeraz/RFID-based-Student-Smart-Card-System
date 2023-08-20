namespace StudentSmartCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ScannedCardInformations", "CardId", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ScannedCardInformations", "CardId", c => c.Int(nullable: false));
        }
    }
}

namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Category", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Description", c => c.String());
            AlterColumn("dbo.tb_Category", "Title", c => c.String());
        }
    }
}

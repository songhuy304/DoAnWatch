namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Alidas", c => c.String());
            AddColumn("dbo.tb_New", "Alidas", c => c.String());
            AddColumn("dbo.tb_Post", "Alidas", c => c.String());
            AddColumn("dbo.tb_Product", "Alidas", c => c.String());
            AlterColumn("dbo.tb_New", "Description", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Post", "Description", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Contact", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Product", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Product", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Description", c => c.String());
            AlterColumn("dbo.tb_Product", "Title", c => c.String());
            AlterColumn("dbo.tb_Contact", "Name", c => c.String());
            AlterColumn("dbo.tb_Post", "Description", c => c.String());
            AlterColumn("dbo.tb_Post", "Title", c => c.String());
            AlterColumn("dbo.tb_New", "Description", c => c.String());
            DropColumn("dbo.tb_Product", "Alidas");
            DropColumn("dbo.tb_Post", "Alidas");
            DropColumn("dbo.tb_New", "Alidas");
            DropColumn("dbo.tb_Category", "Alidas");
        }
    }
}

namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemoinhat1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "SeoTitle");
            DropColumn("dbo.tb_Product", "SeoDescription");
            DropColumn("dbo.tb_Product", "SeoKeywords");
            DropColumn("dbo.tb_ProductCategory", "SeoTitle");
            DropColumn("dbo.tb_ProductCategory", "SeoDescription");
            DropColumn("dbo.tb_ProductCategory", "SeoKeywords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "SeoKeywords", c => c.String());
            AddColumn("dbo.tb_ProductCategory", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_ProductCategory", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
            AddColumn("dbo.tb_Product", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_Product", "SeoTitle", c => c.String());
        }
    }
}

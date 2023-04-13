namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tiep : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Product", "Alidas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Alidas", c => c.String());
        }
    }
}

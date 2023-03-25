namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "Address", c => c.String());
            DropColumn("dbo.tb_Order", "Addres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "Addres", c => c.String());
            DropColumn("dbo.tb_Order", "Address");
        }
    }
}

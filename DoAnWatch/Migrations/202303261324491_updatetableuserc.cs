namespace DoAnWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableuserc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_New", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_New", new[] { "CategoryId" });
            CreateTable(
                "dbo.Userrs",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Fullname = c.String(),
                        IsAdmin = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserID);
          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Subscribe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_New",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Alidas = c.String(),
                        Description = c.String(maxLength: 150),
                        Detail = c.String(),
                        Image = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Adv",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        Link = c.String(),
                        Type = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Userrs");
            CreateIndex("dbo.tb_New", "CategoryId");
            AddForeignKey("dbo.tb_New", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}

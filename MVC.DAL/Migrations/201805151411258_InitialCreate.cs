namespace MVC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogEntities",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogEntities");
        }
    }
}

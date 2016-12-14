namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        AuthorClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthorClasses", t => t.AuthorClassId, cascadeDelete: true)
                .Index(t => t.AuthorClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClasses", "AuthorClassId", "dbo.AuthorClasses");
            DropIndex("dbo.BookClasses", new[] { "AuthorClassId" });
            DropTable("dbo.BookClasses");
            DropTable("dbo.AuthorClasses");
        }
    }
}

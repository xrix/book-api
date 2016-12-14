namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInit02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookClasses", "AuthorClassId", "dbo.AuthorClasses");
            DropForeignKey("dbo.BookClasses", "StudentClassId", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "AuthorClassId" });
            DropIndex("dbo.BookClasses", new[] { "StudentClassId" });
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        AuthorId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.AuthorClasses");
            DropTable("dbo.BookClasses");
            DropTable("dbo.StudentClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentClasses",
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
                        StudentClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Books", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "StudentId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Students");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            CreateIndex("dbo.BookClasses", "StudentClassId");
            CreateIndex("dbo.BookClasses", "AuthorClassId");
            AddForeignKey("dbo.BookClasses", "StudentClassId", "dbo.StudentClasses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookClasses", "AuthorClassId", "dbo.AuthorClasses", "Id", cascadeDelete: true);
        }
    }
}

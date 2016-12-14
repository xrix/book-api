namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editO2mNremove2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookClasses", "StudentID", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "StudentID" });
            AddColumn("dbo.BookClasses", "StudentClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookClasses", "StudentClassId");
            AddForeignKey("dbo.BookClasses", "StudentClassId", "dbo.StudentClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClasses", "StudentClassId", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "StudentClassId" });
            DropColumn("dbo.BookClasses", "StudentClassId");
            CreateIndex("dbo.BookClasses", "StudentID");
            AddForeignKey("dbo.BookClasses", "StudentID", "dbo.StudentClasses", "Id", cascadeDelete: true);
        }
    }
}

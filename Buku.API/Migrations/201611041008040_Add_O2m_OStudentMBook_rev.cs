namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_O2m_OStudentMBook_rev : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookClasses", "StudentID_Id", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "StudentID_Id" });
            RenameColumn(table: "dbo.BookClasses", name: "StudentID_Id", newName: "StudentID");
            AlterColumn("dbo.BookClasses", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.BookClasses", "StudentID");
            AddForeignKey("dbo.BookClasses", "StudentID", "dbo.StudentClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClasses", "StudentID", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "StudentID" });
            AlterColumn("dbo.BookClasses", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.BookClasses", name: "StudentID", newName: "StudentID_Id");
            CreateIndex("dbo.BookClasses", "StudentID_Id");
            AddForeignKey("dbo.BookClasses", "StudentID_Id", "dbo.StudentClasses", "Id");
        }
    }
}

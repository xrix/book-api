namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_studentId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookClasses", name: "Student_Id", newName: "StudentID_Id");
            RenameIndex(table: "dbo.BookClasses", name: "IX_Student_Id", newName: "IX_StudentID_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BookClasses", name: "IX_StudentID_Id", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.BookClasses", name: "StudentID_Id", newName: "Student_Id");
        }
    }
}

namespace Buku.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_O2m_OStudentMBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BookClasses", "Student_Id", c => c.Int());
            CreateIndex("dbo.BookClasses", "Student_Id");
            AddForeignKey("dbo.BookClasses", "Student_Id", "dbo.StudentClasses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClasses", "Student_Id", "dbo.StudentClasses");
            DropIndex("dbo.BookClasses", new[] { "Student_Id" });
            DropColumn("dbo.BookClasses", "Student_Id");
            DropTable("dbo.StudentClasses");
        }
    }
}

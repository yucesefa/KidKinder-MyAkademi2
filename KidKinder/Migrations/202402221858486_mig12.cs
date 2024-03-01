namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parents", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Parents", "StudentId", "dbo.Students");
            DropIndex("dbo.Parents", new[] { "StudentId" });
            DropIndex("dbo.Parents", new[] { "ClassRoomId" });
            AddColumn("dbo.BookASeats", "PhoneNumber", c => c.String());
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        StudentId = c.Int(nullable: false),
                        ClassRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentId);
            
            DropColumn("dbo.BookASeats", "PhoneNumber");
            CreateIndex("dbo.Parents", "ClassRoomId");
            CreateIndex("dbo.Parents", "StudentId");
            AddForeignKey("dbo.Parents", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Parents", "ClassRoomId", "dbo.ClassRooms", "ClassRoomId", cascadeDelete: true);
        }
    }
}

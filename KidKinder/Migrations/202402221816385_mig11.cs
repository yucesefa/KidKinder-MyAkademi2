namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassRoomId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Parents", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.Parents", new[] { "ClassRoomId" });
            DropIndex("dbo.Parents", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Parents");
        }
    }
}

namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.BookASeats", new[] { "ClassRoomId" });
            AddColumn("dbo.BookASeats", "ClassRoomName", c => c.String());
            DropColumn("dbo.BookASeats", "ClassRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookASeats", "ClassRoomId", c => c.Int(nullable: false));
            DropColumn("dbo.BookASeats", "ClassRoomName");
            CreateIndex("dbo.BookASeats", "ClassRoomId");
            AddForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms", "ClassRoomId", cascadeDelete: true);
        }
    }
}

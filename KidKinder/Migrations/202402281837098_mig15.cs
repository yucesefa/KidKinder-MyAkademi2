namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookASeats", "ClassRoomId", c => c.Int());
            AddColumn("dbo.BookASeats", "BookASeats_BookASeatId", c => c.Int());
            CreateIndex("dbo.BookASeats", "ClassRoomId");
            CreateIndex("dbo.BookASeats", "BookASeats_BookASeatId");
            AddForeignKey("dbo.BookASeats", "BookASeats_BookASeatId", "dbo.BookASeats", "BookASeatId");
            AddForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms", "ClassRoomId");
            DropColumn("dbo.BookASeats", "ClassRoomName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookASeats", "ClassRoomName", c => c.String());
            DropForeignKey("dbo.BookASeats", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.BookASeats", "BookASeats_BookASeatId", "dbo.BookASeats");
            DropIndex("dbo.BookASeats", new[] { "BookASeats_BookASeatId" });
            DropIndex("dbo.BookASeats", new[] { "ClassRoomId" });
            DropColumn("dbo.BookASeats", "BookASeats_BookASeatId");
            DropColumn("dbo.BookASeats", "ClassRoomId");
        }
    }
}

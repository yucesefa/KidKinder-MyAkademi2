namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookASeats", "BookASeats_BookASeatId", "dbo.BookASeats");
            DropIndex("dbo.BookASeats", new[] { "BookASeats_BookASeatId" });
            DropColumn("dbo.BookASeats", "BookASeats_BookASeatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookASeats", "BookASeats_BookASeatId", c => c.Int());
            CreateIndex("dbo.BookASeats", "BookASeats_BookASeatId");
            AddForeignKey("dbo.BookASeats", "BookASeats_BookASeatId", "dbo.BookASeats", "BookASeatId");
        }
    }
}

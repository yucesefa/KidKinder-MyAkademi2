namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "StatusImage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "StatusImage");
        }
    }
}

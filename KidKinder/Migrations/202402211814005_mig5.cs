namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Galleries", "Header");
            DropColumn("dbo.Galleries", "Title");
            DropColumn("dbo.Galleries", "Buttons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Galleries", "Buttons", c => c.String());
            AddColumn("dbo.Galleries", "Title", c => c.String());
            AddColumn("dbo.Galleries", "Header", c => c.String());
        }
    }
}

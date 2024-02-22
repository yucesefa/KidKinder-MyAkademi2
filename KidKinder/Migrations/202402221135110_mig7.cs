namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teachers", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "BranchId", c => c.Int(nullable: false));
        }
    }
}

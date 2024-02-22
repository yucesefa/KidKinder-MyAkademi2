namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "BranchId", "dbo.Branches");
            DropIndex("dbo.Teachers", new[] { "BranchId" });
            //DropTable("dbo.Branches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateIndex("dbo.Teachers", "BranchId");
            AddForeignKey("dbo.Teachers", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
    }
}

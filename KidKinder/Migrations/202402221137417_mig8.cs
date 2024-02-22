﻿namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            AddColumn("dbo.Teachers", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "BranchId");
            AddForeignKey("dbo.Teachers", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "BranchId", "dbo.Branches");
            DropIndex("dbo.Teachers", new[] { "BranchId" });
            DropColumn("dbo.Teachers", "BranchId");
            DropTable("dbo.Branches");
        }
    }
}
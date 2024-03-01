namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SocialMedias", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.SocialMedias", new[] { "TeacherId" });
            DropTable("dbo.SocialMedias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaId = c.Int(nullable: false, identity: true),
                        Twitter = c.String(),
                        Facebook = c.String(),
                        Linekdin = c.String(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SocialMediaId);
            
            CreateIndex("dbo.SocialMedias", "TeacherId");
            AddForeignKey("dbo.SocialMedias", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}

namespace KidKinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.SocialMediaId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMedias", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.SocialMedias", new[] { "TeacherId" });
            DropTable("dbo.SocialMedias");
        }
    }
}

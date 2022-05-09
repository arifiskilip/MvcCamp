namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CvSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SkillName = c.String(),
                        SkillPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CvUserInfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CvUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Age = c.String(),
                        School = c.String(),
                        Department = c.String(),
                        LinkedinUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CvSkills", "UserId", "dbo.CvUserInfoes");
            DropIndex("dbo.CvSkills", new[] { "UserId" });
            DropTable("dbo.CvUserInfoes");
            DropTable("dbo.CvSkills");
        }
    }
}

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbaoutStatuAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Statu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "Statu");
        }
    }
}

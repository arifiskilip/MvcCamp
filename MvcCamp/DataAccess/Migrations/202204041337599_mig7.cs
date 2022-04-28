namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "Statu", c => c.Boolean(nullable: false));
            DropColumn("dbo.Headings", "statust");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "statust", c => c.Boolean(nullable: false));
            DropColumn("dbo.Headings", "Statu");
        }
    }
}

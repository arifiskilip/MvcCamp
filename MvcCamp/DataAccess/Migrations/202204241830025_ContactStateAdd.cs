namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactStateAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "State");
        }
    }
}

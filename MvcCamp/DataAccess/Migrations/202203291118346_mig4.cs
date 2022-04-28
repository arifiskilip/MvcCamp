namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "Writer_Id", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "Writer_Id" });
            RenameColumn(table: "dbo.Headings", name: "Writer_Id", newName: "WriterId");
            AlterColumn("dbo.Headings", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Headings", "WriterId");
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterId" });
            AlterColumn("dbo.Headings", "WriterId", c => c.Int());
            RenameColumn(table: "dbo.Headings", name: "WriterId", newName: "Writer_Id");
            CreateIndex("dbo.Headings", "Writer_Id");
            AddForeignKey("dbo.Headings", "Writer_Id", "dbo.Writers", "Id");
        }
    }
}

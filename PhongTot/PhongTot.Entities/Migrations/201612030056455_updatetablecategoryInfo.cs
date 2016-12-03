namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablecategoryInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "CreatedDate");
            DropColumn("dbo.PostCategories", "Status");
        }
    }
}

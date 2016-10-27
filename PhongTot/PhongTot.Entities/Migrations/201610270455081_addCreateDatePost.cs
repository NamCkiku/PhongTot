namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreateDatePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "MoreImages", c => c.String(storeType: "xml"));
            AddColumn("dbo.Posts", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Posts", "ExpireDate", c => c.DateTime());
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Posts", "ExpireDate");
            DropColumn("dbo.Posts", "CreateDate");
            DropColumn("dbo.Posts", "MoreImages");
        }
    }
}

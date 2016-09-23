namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneInTableInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Info", "Phone", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Info", "Phone");
        }
    }
}

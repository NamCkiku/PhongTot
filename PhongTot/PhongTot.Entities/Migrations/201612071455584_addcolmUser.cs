namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolmUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationUsers", "CreatedBy", c => c.String());
            AddColumn("dbo.ApplicationUsers", "Country", c => c.String());
            AddColumn("dbo.ApplicationUsers", "Skill", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Skill");
            DropColumn("dbo.ApplicationUsers", "Country");
            DropColumn("dbo.ApplicationUsers", "CreatedBy");
            DropColumn("dbo.ApplicationUsers", "CreatedDate");
        }
    }
}

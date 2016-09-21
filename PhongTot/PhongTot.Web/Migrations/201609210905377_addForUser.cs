namespace PhongTot.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "Avater", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "Avater");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}

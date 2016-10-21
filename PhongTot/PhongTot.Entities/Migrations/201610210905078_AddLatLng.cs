namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLatLng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Info", "Lat", c => c.Double());
            AddColumn("dbo.Info", "Lng", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Info", "Lng");
            DropColumn("dbo.Info", "Lat");
        }
    }
}

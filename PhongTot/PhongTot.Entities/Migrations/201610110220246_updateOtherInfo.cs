namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOtherInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OtherInfo", "ElectricPrice", c => c.Int(nullable: false));
            AddColumn("dbo.OtherInfo", "WaterPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.OtherInfo", "Convenient", c => c.String(storeType: "xml"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OtherInfo", "Convenient", c => c.String());
            DropColumn("dbo.OtherInfo", "WaterPrice");
            DropColumn("dbo.OtherInfo", "ElectricPrice");
        }
    }
}

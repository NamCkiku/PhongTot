namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWaterPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OtherInfo", "ElectricPrice", c => c.Int());
            AlterColumn("dbo.OtherInfo", "WaterPrice", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OtherInfo", "WaterPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.OtherInfo", "ElectricPrice", c => c.Int(nullable: false));
        }
    }
}

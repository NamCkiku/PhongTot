namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableInfoOther : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OtherInfo", "FloorNumber", c => c.String());
            AlterColumn("dbo.OtherInfo", "ToiletNumber", c => c.String());
            AlterColumn("dbo.OtherInfo", "BedroomNumber", c => c.String());
            AlterColumn("dbo.OtherInfo", "Compass", c => c.String());
            AlterColumn("dbo.OtherInfo", "Convenient", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OtherInfo", "Convenient", c => c.Int());
            AlterColumn("dbo.OtherInfo", "Compass", c => c.Int());
            AlterColumn("dbo.OtherInfo", "BedroomNumber", c => c.Int());
            AlterColumn("dbo.OtherInfo", "ToiletNumber", c => c.Int());
            AlterColumn("dbo.OtherInfo", "FloorNumber", c => c.Int());
        }
    }
}

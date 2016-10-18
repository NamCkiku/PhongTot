namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Info",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 256),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 256),
                        MoreImages = c.String(storeType: "xml"),
                        Wardid = c.Int(),
                        Districtid = c.Int(),
                        Provinceid = c.Int(),
                        Acreage = c.Double(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherInfoID = c.Int(),
                        Description = c.String(maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        CreateDate = c.DateTime(),
                        ExpireDate = c.DateTime(),
                        ViewCount = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districtid", t => t.Districtid)
                .ForeignKey("dbo.Province", t => t.Provinceid)
                .ForeignKey("dbo.Wardid", t => t.Wardid)
                .ForeignKey("dbo.OtherInfo", t => t.OtherInfoID)
                .ForeignKey("dbo.CategoryInfo", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.Wardid)
                .Index(t => t.Districtid)
                .Index(t => t.Provinceid)
                .Index(t => t.OtherInfoID);
            
            CreateTable(
                "dbo.Districtid",
                c => new
                    {
                        districtid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        location = c.String(maxLength: 255),
                        provinceid = c.Int(),
                    })
                .PrimaryKey(t => t.districtid)
                .ForeignKey("dbo.Province", t => t.provinceid)
                .Index(t => t.provinceid);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        provinceid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.provinceid);
            
            CreateTable(
                "dbo.Wardid",
                c => new
                    {
                        wardid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        location = c.String(maxLength: 255),
                        districtid = c.Int(),
                    })
                .PrimaryKey(t => t.wardid)
                .ForeignKey("dbo.Districtid", t => t.districtid)
                .Index(t => t.districtid);
            
            CreateTable(
                "dbo.OtherInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FloorNumber = c.String(),
                        ToiletNumber = c.String(),
                        BedroomNumber = c.String(),
                        Compass = c.String(),
                        ElectricPrice = c.Int(),
                        WaterPrice = c.Int(),
                        Convenient = c.String(storeType: "xml"),
                        CategoryOtherInfoID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CategoryOtherInfo", t => t.CategoryOtherInfoID)
                .Index(t => t.CategoryOtherInfoID);
            
            CreateTable(
                "dbo.CategoryOtherInfo",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Info", "CategoryID", "dbo.CategoryInfo");
            DropForeignKey("dbo.Info", "OtherInfoID", "dbo.OtherInfo");
            DropForeignKey("dbo.OtherInfo", "CategoryOtherInfoID", "dbo.CategoryOtherInfo");
            DropForeignKey("dbo.Wardid", "districtid", "dbo.Districtid");
            DropForeignKey("dbo.Info", "Wardid", "dbo.Wardid");
            DropForeignKey("dbo.Info", "Provinceid", "dbo.Province");
            DropForeignKey("dbo.Districtid", "provinceid", "dbo.Province");
            DropForeignKey("dbo.Info", "Districtid", "dbo.Districtid");
            DropIndex("dbo.OtherInfo", new[] { "CategoryOtherInfoID" });
            DropIndex("dbo.Wardid", new[] { "districtid" });
            DropIndex("dbo.Districtid", new[] { "provinceid" });
            DropIndex("dbo.Info", new[] { "OtherInfoID" });
            DropIndex("dbo.Info", new[] { "Provinceid" });
            DropIndex("dbo.Info", new[] { "Districtid" });
            DropIndex("dbo.Info", new[] { "Wardid" });
            DropIndex("dbo.Info", new[] { "CategoryID" });
            DropTable("dbo.Error");
            DropTable("dbo.CategoryOtherInfo");
            DropTable("dbo.OtherInfo");
            DropTable("dbo.Wardid");
            DropTable("dbo.Province");
            DropTable("dbo.Districtid");
            DropTable("dbo.Info");
            DropTable("dbo.CategoryInfo");
        }
    }
}

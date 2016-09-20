namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMuc",
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
                "dbo.ThongTin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 256),
                        MoreImages = c.String(storeType: "xml"),
                        Wardid = c.Int(),
                        Districtid = c.Int(),
                        Provinceid = c.Int(),
                        Acreage = c.Double(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InformationAddID = c.Int(),
                        Description = c.String(maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        CreateDate = c.DateTime(),
                        ExpireDate = c.DateTime(),
                        ViewCount = c.Int(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Quanhuyen", t => t.Districtid)
                .ForeignKey("dbo.Tinhthanh", t => t.Provinceid)
                .ForeignKey("dbo.Phuongxa", t => t.Wardid)
                .ForeignKey("dbo.ThongTinThem", t => t.InformationAddID)
                .ForeignKey("dbo.DanhMuc", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.Wardid)
                .Index(t => t.Districtid)
                .Index(t => t.Provinceid)
                .Index(t => t.InformationAddID);
            
            CreateTable(
                "dbo.Phuongxa",
                c => new
                    {
                        wardid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        location = c.String(maxLength: 255),
                        districtid = c.Int(),
                    })
                .PrimaryKey(t => t.wardid)
                .ForeignKey("dbo.Quanhuyen", t => t.districtid)
                .Index(t => t.districtid);
            
            CreateTable(
                "dbo.Quanhuyen",
                c => new
                    {
                        districtid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                        location = c.String(maxLength: 255),
                        provinceid = c.Int(),
                    })
                .PrimaryKey(t => t.districtid)
                .ForeignKey("dbo.Tinhthanh", t => t.provinceid)
                .Index(t => t.provinceid);
            
            CreateTable(
                "dbo.Tinhthanh",
                c => new
                    {
                        provinceid = c.Int(nullable: false),
                        name = c.String(maxLength: 255),
                        type = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.provinceid);
            
            CreateTable(
                "dbo.ThongTinThem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FloorNumberID = c.Int(),
                        ToiletNumberID = c.Int(),
                        BedroomNumberID = c.Int(),
                        CompassID = c.Int(),
                        ConvenientID = c.Int(),
                        InformatinAddCategory = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DanhMucThongTinThem", t => t.InformatinAddCategory)
                .ForeignKey("dbo.HuongNha", t => t.CompassID)
                .ForeignKey("dbo.SoPhongNgu", t => t.BedroomNumberID)
                .ForeignKey("dbo.SoPhongVeSinh", t => t.ToiletNumberID)
                .ForeignKey("dbo.SoTang", t => t.FloorNumberID)
                .ForeignKey("dbo.TienNghi", t => t.ConvenientID)
                .Index(t => t.FloorNumberID)
                .Index(t => t.ToiletNumberID)
                .Index(t => t.BedroomNumberID)
                .Index(t => t.CompassID)
                .Index(t => t.ConvenientID)
                .Index(t => t.InformatinAddCategory);
            
            CreateTable(
                "dbo.DanhMucThongTinThem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InformatinAddCategory = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HuongNha",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Compass = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SoPhongNgu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BedroomNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SoPhongVeSinh",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToiletNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SoTang",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FloorNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TienNghi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Convenient = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThongTin", "CategoryID", "dbo.DanhMuc");
            DropForeignKey("dbo.ThongTinThem", "ConvenientID", "dbo.TienNghi");
            DropForeignKey("dbo.ThongTin", "InformationAddID", "dbo.ThongTinThem");
            DropForeignKey("dbo.ThongTinThem", "FloorNumberID", "dbo.SoTang");
            DropForeignKey("dbo.ThongTinThem", "ToiletNumberID", "dbo.SoPhongVeSinh");
            DropForeignKey("dbo.ThongTinThem", "BedroomNumberID", "dbo.SoPhongNgu");
            DropForeignKey("dbo.ThongTinThem", "CompassID", "dbo.HuongNha");
            DropForeignKey("dbo.ThongTinThem", "InformatinAddCategory", "dbo.DanhMucThongTinThem");
            DropForeignKey("dbo.ThongTin", "Wardid", "dbo.Phuongxa");
            DropForeignKey("dbo.ThongTin", "Provinceid", "dbo.Tinhthanh");
            DropForeignKey("dbo.Quanhuyen", "provinceid", "dbo.Tinhthanh");
            DropForeignKey("dbo.ThongTin", "Districtid", "dbo.Quanhuyen");
            DropForeignKey("dbo.Phuongxa", "districtid", "dbo.Quanhuyen");
            DropIndex("dbo.ThongTinThem", new[] { "InformatinAddCategory" });
            DropIndex("dbo.ThongTinThem", new[] { "ConvenientID" });
            DropIndex("dbo.ThongTinThem", new[] { "CompassID" });
            DropIndex("dbo.ThongTinThem", new[] { "BedroomNumberID" });
            DropIndex("dbo.ThongTinThem", new[] { "ToiletNumberID" });
            DropIndex("dbo.ThongTinThem", new[] { "FloorNumberID" });
            DropIndex("dbo.Quanhuyen", new[] { "provinceid" });
            DropIndex("dbo.Phuongxa", new[] { "districtid" });
            DropIndex("dbo.ThongTin", new[] { "InformationAddID" });
            DropIndex("dbo.ThongTin", new[] { "Provinceid" });
            DropIndex("dbo.ThongTin", new[] { "Districtid" });
            DropIndex("dbo.ThongTin", new[] { "Wardid" });
            DropIndex("dbo.ThongTin", new[] { "CategoryID" });
            DropTable("dbo.TienNghi");
            DropTable("dbo.SoTang");
            DropTable("dbo.SoPhongVeSinh");
            DropTable("dbo.SoPhongNgu");
            DropTable("dbo.HuongNha");
            DropTable("dbo.DanhMucThongTinThem");
            DropTable("dbo.ThongTinThem");
            DropTable("dbo.Tinhthanh");
            DropTable("dbo.Quanhuyen");
            DropTable("dbo.Phuongxa");
            DropTable("dbo.ThongTin");
            DropTable("dbo.DanhMuc");
        }
    }
}

namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsyspara : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysPara",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Field = c.String(),
                        Value = c.String(),
                        ValDefault = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysPara");
        }
    }
}

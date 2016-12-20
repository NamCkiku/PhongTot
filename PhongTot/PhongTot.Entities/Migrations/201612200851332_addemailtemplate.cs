namespace PhongTot.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemailtemplate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Subject = c.String(nullable: false, maxLength: 256),
                        Body = c.String(storeType: "ntext"),
                        SMTPHost = c.String(),
                        SMTPEmailAddress = c.String(),
                        SMTPEmailPassword = c.String(),
                        SMTPPort = c.String(),
                        SMTPEnableSSL = c.String(),
                        LanguageUse = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailTemplates");
        }
    }
}

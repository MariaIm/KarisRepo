namespace KarisMissionChoir.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearAppUserAndMediaImage1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "PhotoId", c => c.Int());
            DropColumn("dbo.Users", "MemberPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "MemberPhoto", c => c.Binary());
            DropColumn("dbo.Users", "PhotoId");
            DropTable("dbo.MediaImage");
        }
    }
}

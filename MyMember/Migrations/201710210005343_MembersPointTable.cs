namespace MyMember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembersPointTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembersPointTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Point = c.Int(nullable: false),
                        PointValue = c.Int(nullable: false),
                        MinimumPayoutPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembersPointTables");
        }
    }
}

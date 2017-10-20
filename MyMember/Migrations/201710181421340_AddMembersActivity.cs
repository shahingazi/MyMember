namespace MyMember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembersActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembersActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Text = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembersActivities", "MemberId", "dbo.Members");
            DropIndex("dbo.MembersActivities", new[] { "MemberId" });
            DropTable("dbo.MembersActivities");
        }
    }
}

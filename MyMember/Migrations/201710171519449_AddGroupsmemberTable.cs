namespace MyMember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupsmemberTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupsMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateAt = c.DateTime(nullable: false),
                        Members_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Members_Id)
                .Index(t => t.Members_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupsMembers", "Members_Id", "dbo.Members");
            DropIndex("dbo.GroupsMembers", new[] { "Members_Id" });
            DropTable("dbo.GroupsMembers");
        }
    }
}

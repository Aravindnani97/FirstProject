namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipWithCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipId");
            AddForeignKey("dbo.Customers", "MembershipId", "dbo.Memberships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipId" });
            DropColumn("dbo.Customers", "MembershipId");
        }
    }
}

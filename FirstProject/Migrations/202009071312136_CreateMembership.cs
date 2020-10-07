namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMembership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipType = c.String(),
                        SignUpFee = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Memberships");
        }
    }
}

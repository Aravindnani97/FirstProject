namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfBirthNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DateofBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DateofBirth", c => c.DateTime(nullable: false));
        }
    }
}

namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNullToNameAndDirectorName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "DirectorName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DirectorName", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}

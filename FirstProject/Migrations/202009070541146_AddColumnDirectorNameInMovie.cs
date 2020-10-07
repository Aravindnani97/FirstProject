namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDirectorNameInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DirectorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DirectorName");
        }
    }
}

namespace FirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert Genres(GenreName) values('Action')");
            Sql("insert Genres(GenreName) values('Comedy')");
            Sql("insert Genres(GenreName) values('Thriller')");
            Sql("insert Genres(GenreName) values('Horror')");
            Sql("insert Genres(GenreName) values('Animation')");

        }

        public override void Down()
        {
        }
    }
}

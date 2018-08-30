namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletando_coluna_dias : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Turma", "Dias");
        }
        
        public override void Down()
        {
        }
    }
}

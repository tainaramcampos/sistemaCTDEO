namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo_atributo_modalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modalidade", "Nivel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modalidade", "Nivel");
        }
    }
}

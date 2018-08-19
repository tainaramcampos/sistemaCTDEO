namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo_atributo_modalidade1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Modalidade", "Categoria");
            DropColumn("dbo.Modalidade", "Nivel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modalidade", "Nivel", c => c.Int(nullable: false));
            AddColumn("dbo.Modalidade", "Categoria", c => c.String());
        }
    }
}

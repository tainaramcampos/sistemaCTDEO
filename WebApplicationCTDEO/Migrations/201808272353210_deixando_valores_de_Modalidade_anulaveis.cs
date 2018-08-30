namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deixando_valores_de_Modalidade_anulaveis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modalidade", "Nivel", c => c.Int());
            AlterColumn("dbo.Modalidade", "GrupoAtl", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modalidade", "GrupoAtl", c => c.Int(nullable: false));
            AlterColumn("dbo.Modalidade", "Nivel", c => c.Int(nullable: false));
        }
    }
}

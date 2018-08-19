namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generalizacao_modalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modalidade", "Categoria", c => c.Int());
            AddColumn("dbo.Modalidade", "Nivel", c => c.Int());
            AddColumn("dbo.Modalidade", "Categoria1", c => c.Int());
            AddColumn("dbo.Modalidade", "Nivel1", c => c.Int());
            AddColumn("dbo.Modalidade", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modalidade", "Discriminator");
            DropColumn("dbo.Modalidade", "Nivel1");
            DropColumn("dbo.Modalidade", "Categoria1");
            DropColumn("dbo.Modalidade", "Nivel");
            DropColumn("dbo.Modalidade", "Categoria");
        }
    }
}

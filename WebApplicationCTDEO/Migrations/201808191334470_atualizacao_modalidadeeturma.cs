namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacao_modalidadeeturma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "Turno", c => c.Int(nullable: false));
            AddColumn("dbo.Modalidade", "NivelAtletismo", c => c.Int());
            AddColumn("dbo.Modalidade", "Grupo", c => c.Int());
            AddColumn("dbo.Modalidade", "NivelFutebol", c => c.Int());
            DropColumn("dbo.Modalidade", "Categoria");
            DropColumn("dbo.Modalidade", "Nivel");
            DropColumn("dbo.Modalidade", "Categoria1");
            DropColumn("dbo.Modalidade", "Nivel1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modalidade", "Nivel1", c => c.Int());
            AddColumn("dbo.Modalidade", "Categoria1", c => c.Int());
            AddColumn("dbo.Modalidade", "Nivel", c => c.Int());
            AddColumn("dbo.Modalidade", "Categoria", c => c.Int());
            DropColumn("dbo.Modalidade", "NivelFutebol");
            DropColumn("dbo.Modalidade", "Grupo");
            DropColumn("dbo.Modalidade", "NivelAtletismo");
            DropColumn("dbo.Turma", "Turno");
        }
    }
}

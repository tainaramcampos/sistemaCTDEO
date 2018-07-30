namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_nome_atributo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "SistemadeEnsino", c => c.Int(nullable: false));
            DropColumn("dbo.Aluno", "TipodeInstituicao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "TipodeInstituicao", c => c.Int(nullable: false));
            DropColumn("dbo.Aluno", "SistemadeEnsino");
        }
    }
}

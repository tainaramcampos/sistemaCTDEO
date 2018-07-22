namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exclusao_de_tabelas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Bairro", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Bairro", c => c.String());
            AlterColumn("dbo.Aluno", "Endereco", c => c.String());
            AlterColumn("dbo.Aluno", "Nome", c => c.String());
        }
    }
}

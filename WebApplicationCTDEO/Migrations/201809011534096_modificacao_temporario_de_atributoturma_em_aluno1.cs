namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_temporario_de_atributoturma_em_aluno1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "IdsdeTurmas", c => c.String());
            DropColumn("dbo.Aluno", "NomesdeTurmas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "NomesdeTurmas", c => c.String());
            DropColumn("dbo.Aluno", "IdsdeTurmas");
        }
    }
}

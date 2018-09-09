namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_temporario_de_atributoturma_em_aluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "NomesdeTurmas", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "NomesdeTurmas");
        }
    }
}

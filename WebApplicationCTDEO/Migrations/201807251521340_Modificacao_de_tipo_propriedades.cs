namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacao_de_tipo_propriedades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlunoSocial", "EnfermidadesnaFamilia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlunoSocial", "EnfermidadesnaFamilia");
        }
    }
}

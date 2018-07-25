namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacao_de_tipo_propriedades3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "TipodeBolsaAtleta", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "TipodeBolsaAtleta", c => c.Int(nullable: false));
        }
    }
}

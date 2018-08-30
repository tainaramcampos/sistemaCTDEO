namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacoes_em_modalidade_e_turma2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "ListString", c => c.String());
            DropTable("dbo.DiadaSemana");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiadaSemana",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Turma", "ListString");
        }
    }
}

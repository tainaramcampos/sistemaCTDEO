namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacoes_em_modalidade_e_turma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiadaSemana", "Turma_TurmaId", "dbo.Turma");
            DropIndex("dbo.DiadaSemana", new[] { "Turma_TurmaId" });
            DropColumn("dbo.DiadaSemana", "Turma_TurmaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiadaSemana", "Turma_TurmaId", c => c.Int());
            CreateIndex("dbo.DiadaSemana", "Turma_TurmaId");
            AddForeignKey("dbo.DiadaSemana", "Turma_TurmaId", "dbo.Turma", "TurmaId");
        }
    }
}

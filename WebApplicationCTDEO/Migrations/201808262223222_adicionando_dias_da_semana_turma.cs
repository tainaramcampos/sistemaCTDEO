namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionando_dias_da_semana_turma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiadaSemana",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomes = c.String(),
                        Turma_TurmaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .Index(t => t.Turma_TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiadaSemana", "Turma_TurmaId", "dbo.Turma");
            DropIndex("dbo.DiadaSemana", new[] { "Turma_TurmaId" });
            DropTable("dbo.DiadaSemana");
        }
    }
}

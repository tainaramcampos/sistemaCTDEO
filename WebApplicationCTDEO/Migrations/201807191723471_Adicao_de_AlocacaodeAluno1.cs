namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicao_de_AlocacaodeAluno1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlocacaoDeAluno",
                c => new
                    {
                        AlocacaoId = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlocacaoId)
                .ForeignKey("dbo.Aluno", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Turma", t => t.TurmaId, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlocacaoDeAluno", "TurmaId", "dbo.Turma");
            DropForeignKey("dbo.AlocacaoDeAluno", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.AlocacaoDeAluno", new[] { "TurmaId" });
            DropIndex("dbo.AlocacaoDeAluno", new[] { "AlunoId" });
            DropTable("dbo.AlocacaoDeAluno");
        }
    }
}

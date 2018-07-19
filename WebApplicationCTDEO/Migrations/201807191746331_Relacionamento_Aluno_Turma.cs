namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relacionamento_Aluno_Turma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turma", "TurmaId", "dbo.Aluno");
            DropForeignKey("dbo.AlocacaoDeAluno", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.AlocacaoDeAluno", "TurmaId", "dbo.Turma");
            DropIndex("dbo.AlocacaoDeAluno", new[] { "AlunoId" });
            DropIndex("dbo.AlocacaoDeAluno", new[] { "TurmaId" });
            DropIndex("dbo.Turma", new[] { "TurmaId" });
            DropPrimaryKey("dbo.Turma");
            CreateTable(
                "dbo.AlocacaoAluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        Turma_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlunoId, t.Turma_Id })
                .ForeignKey("dbo.Aluno", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Turma", t => t.Turma_Id, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.Turma_Id);
            
            AddColumn("dbo.Aluno", "TurmaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Turma", "TurmaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Turma", "TurmaId");
            DropTable("dbo.AlocacaoDeAluno");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AlocacaoDeAluno",
                c => new
                    {
                        AlocacaoId = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlocacaoId);
            
            DropForeignKey("dbo.AlocacaoAluno", "Turma_Id", "dbo.Turma");
            DropForeignKey("dbo.AlocacaoAluno", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.AlocacaoAluno", new[] { "Turma_Id" });
            DropIndex("dbo.AlocacaoAluno", new[] { "AlunoId" });
            DropPrimaryKey("dbo.Turma");
            AlterColumn("dbo.Turma", "TurmaId", c => c.Int(nullable: false));
            DropColumn("dbo.Aluno", "TurmaId");
            DropTable("dbo.AlocacaoAluno");
            AddPrimaryKey("dbo.Turma", "TurmaId");
            CreateIndex("dbo.Turma", "TurmaId");
            CreateIndex("dbo.AlocacaoDeAluno", "TurmaId");
            CreateIndex("dbo.AlocacaoDeAluno", "AlunoId");
            AddForeignKey("dbo.AlocacaoDeAluno", "TurmaId", "dbo.Turma", "TurmaId", cascadeDelete: true);
            AddForeignKey("dbo.AlocacaoDeAluno", "AlunoId", "dbo.Aluno", "AlunoId", cascadeDelete: true);
            AddForeignKey("dbo.Turma", "TurmaId", "dbo.Aluno", "AlunoId");
        }
    }
}

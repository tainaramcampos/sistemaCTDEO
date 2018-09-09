namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edicao_de_campos_alunos : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TurmaAluno", newName: "AlocacaoAluno");
            RenameColumn(table: "dbo.AlocacaoAluno", name: "Turma_TurmaId", newName: "TurmaId");
            RenameColumn(table: "dbo.AlocacaoAluno", name: "Aluno_AlunoId", newName: "AlunoId");
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_Aluno_AlunoId", newName: "IX_AlunoId");
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_Turma_TurmaId", newName: "IX_Turma_Id");
            DropPrimaryKey("dbo.AlocacaoAluno");
            AddPrimaryKey("dbo.AlocacaoAluno", new[] { "AlunoId", "TurmaId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AlocacaoAluno");
            AddPrimaryKey("dbo.AlocacaoAluno", new[] { "Turma_TurmaId", "Aluno_AlunoId" });
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_Turma_Id", newName: "IX_Turma_TurmaId");
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_AlunoId", newName: "IX_Aluno_AlunoId");
            RenameColumn(table: "dbo.AlocacaoAluno", name: "AlunoId", newName: "Aluno_AlunoId");
            RenameColumn(table: "dbo.AlocacaoAluno", name: "TurmaId", newName: "Turma_TurmaId");
            RenameTable(name: "dbo.AlocacaoAluno", newName: "TurmaAluno");
        }
    }
}

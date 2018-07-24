namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova_configuracao_NparaN : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Aluno_Familiar", newName: "FamiliarAluno");
            RenameTable(name: "dbo.AlocacaoAluno", newName: "TurmaAluno");
            RenameColumn(table: "dbo.FamiliarAluno", name: "AlunoId", newName: "Aluno_AlunoId");
            RenameColumn(table: "dbo.FamiliarAluno", name: "Familiar_Id", newName: "Familiar_CPF");
            RenameColumn(table: "dbo.TurmaAluno", name: "AlunoId", newName: "Aluno_AlunoId");
            RenameColumn(table: "dbo.TurmaAluno", name: "Turma_Id", newName: "Turma_TurmaId");
            RenameIndex(table: "dbo.FamiliarAluno", name: "IX_Familiar_Id", newName: "IX_Familiar_CPF");
            RenameIndex(table: "dbo.FamiliarAluno", name: "IX_AlunoId", newName: "IX_Aluno_AlunoId");
            RenameIndex(table: "dbo.TurmaAluno", name: "IX_Turma_Id", newName: "IX_Turma_TurmaId");
            RenameIndex(table: "dbo.TurmaAluno", name: "IX_AlunoId", newName: "IX_Aluno_AlunoId");
            DropPrimaryKey("dbo.FamiliarAluno");
            DropPrimaryKey("dbo.TurmaAluno");
            AddPrimaryKey("dbo.FamiliarAluno", new[] { "Familiar_CPF", "Aluno_AlunoId" });
            AddPrimaryKey("dbo.TurmaAluno", new[] { "Turma_TurmaId", "Aluno_AlunoId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TurmaAluno");
            DropPrimaryKey("dbo.FamiliarAluno");
            AddPrimaryKey("dbo.TurmaAluno", new[] { "AlunoId", "Turma_Id" });
            AddPrimaryKey("dbo.FamiliarAluno", new[] { "AlunoId", "Familiar_Id" });
            RenameIndex(table: "dbo.TurmaAluno", name: "IX_Aluno_AlunoId", newName: "IX_AlunoId");
            RenameIndex(table: "dbo.TurmaAluno", name: "IX_Turma_TurmaId", newName: "IX_Turma_Id");
            RenameIndex(table: "dbo.FamiliarAluno", name: "IX_Aluno_AlunoId", newName: "IX_AlunoId");
            RenameIndex(table: "dbo.FamiliarAluno", name: "IX_Familiar_CPF", newName: "IX_Familiar_Id");
            RenameColumn(table: "dbo.TurmaAluno", name: "Turma_TurmaId", newName: "Turma_Id");
            RenameColumn(table: "dbo.TurmaAluno", name: "Aluno_AlunoId", newName: "AlunoId");
            RenameColumn(table: "dbo.FamiliarAluno", name: "Familiar_CPF", newName: "Familiar_Id");
            RenameColumn(table: "dbo.FamiliarAluno", name: "Aluno_AlunoId", newName: "AlunoId");
            RenameTable(name: "dbo.TurmaAluno", newName: "AlocacaoAluno");
            RenameTable(name: "dbo.FamiliarAluno", newName: "Aluno_Familiar");
        }
    }
}

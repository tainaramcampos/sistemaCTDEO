namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edicao_de_campos_alunos1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AlocacaoAluno", name: "Turma_Id", newName: "TurmaId");
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_Turma_Id", newName: "IX_TurmaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AlocacaoAluno", name: "IX_TurmaId", newName: "IX_Turma_Id");
            RenameColumn(table: "dbo.AlocacaoAluno", name: "TurmaId", newName: "Turma_Id");
        }
    }
}

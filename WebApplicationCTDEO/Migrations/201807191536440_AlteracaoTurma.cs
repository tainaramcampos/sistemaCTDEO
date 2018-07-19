namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoTurma : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Turma", new[] { "Aluno_AlunoId" });
            CreateTable(
                "dbo.AlunoSocial",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        PaisSeparados = c.Boolean(nullable: false),
                        NMoraComPais = c.Boolean(nullable: false),
                        JustificativaNMoraCPais = c.String(),
                        Sustento = c.Int(nullable: false),
                        TrabalhadoresNaFamilia = c.Int(nullable: false),
                        RendaMensal = c.Int(nullable: false),
                        TipodeBeneficio = c.String(),
                        Residencia = c.Int(nullable: false),
                        QtasCriancasEstudando = c.Int(nullable: false),
                        Fumantes = c.String(),
                        Alcoolismo = c.String(),
                        EnvolvidocomDrogas = c.String(),
                        ComoConheceu = c.Int(nullable: false),
                        OutroProjetoqParticipa = c.String(),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .Index(t => t.AlunoId);
            
            CreateTable(
                "dbo.Familiares",
                c => new
                    {
                        FamiliarId = c.Int(nullable: false, identity: true),
                        AlunoSocialId = c.Int(nullable: false),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Vinculo = c.String(),
                        Escolaridade = c.String(),
                        Ocupacao = c.String(),
                    })
                .PrimaryKey(t => t.FamiliarId)
                .ForeignKey("dbo.AlunoSocial", t => t.AlunoSocialId, cascadeDelete: true)
                .Index(t => t.AlunoSocialId);
            
            AddColumn("dbo.Aluno", "NomeResponsavel", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Familiares", "AlunoSocialId", "dbo.AlunoSocial");
            DropForeignKey("dbo.AlunoSocial", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.Familiares", new[] { "AlunoSocialId" });
            DropIndex("dbo.AlunoSocial", new[] { "AlunoId" });
            DropIndex("dbo.Turma", new[] { "TurmaId" });
            DropPrimaryKey("dbo.Turma");
            AlterColumn("dbo.Turma", "TurmaId", c => c.Int());
            AlterColumn("dbo.Turma", "TurmaId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Aluno", "NomeResponsavel");
            DropTable("dbo.Familiares");
            DropTable("dbo.AlunoSocial");
            AddPrimaryKey("dbo.Turma", "TurmaId");
            RenameColumn(table: "dbo.Turma", name: "TurmaId", newName: "Aluno_AlunoId");
            AddColumn("dbo.Turma", "TurmaId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Turma", "Aluno_AlunoId");
        }
    }
}

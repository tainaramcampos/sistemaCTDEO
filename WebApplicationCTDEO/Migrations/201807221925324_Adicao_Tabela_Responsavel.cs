namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicao_Tabela_Responsavel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Familiares", newName: "Moradores");
            CreateTable(
                "dbo.Familiar",
                c => new
                    {
                        CPF = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Profissao = c.String(),
                        GraudeParentesco = c.String(),
                        IsResponsavel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CPF);
            
            CreateTable(
                "dbo.Aluno_Familiar",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        Familiar_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AlunoId, t.Familiar_Id })
                .ForeignKey("dbo.Aluno", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Familiar", t => t.Familiar_Id, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.Familiar_Id);
            
            DropColumn("dbo.Aluno", "MaeCPF");
            DropColumn("dbo.Aluno", "NomeMae");
            DropColumn("dbo.Aluno", "ProfissaoMae");
            DropColumn("dbo.Aluno", "PaiCPF");
            DropColumn("dbo.Aluno", "NomePai");
            DropColumn("dbo.Aluno", "ProfissaoPai");
            DropColumn("dbo.Aluno", "EscolhaResponsavel");
            DropColumn("dbo.Aluno", "ParentescoResp");
            DropColumn("dbo.Aluno", "RespCPF");
            DropColumn("dbo.Aluno", "NomeReponsavel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "NomeReponsavel", c => c.String(nullable: false));
            AddColumn("dbo.Aluno", "RespCPF", c => c.String());
            AddColumn("dbo.Aluno", "ParentescoResp", c => c.String(nullable: false));
            AddColumn("dbo.Aluno", "EscolhaResponsavel", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "ProfissaoPai", c => c.String());
            AddColumn("dbo.Aluno", "NomePai", c => c.String());
            AddColumn("dbo.Aluno", "PaiCPF", c => c.String());
            AddColumn("dbo.Aluno", "ProfissaoMae", c => c.String());
            AddColumn("dbo.Aluno", "NomeMae", c => c.String());
            AddColumn("dbo.Aluno", "MaeCPF", c => c.String());
            DropForeignKey("dbo.Aluno_Familiar", "Familiar_Id", "dbo.Familiar");
            DropForeignKey("dbo.Aluno_Familiar", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.Aluno_Familiar", new[] { "Familiar_Id" });
            DropIndex("dbo.Aluno_Familiar", new[] { "AlunoId" });
            DropTable("dbo.Aluno_Familiar");
            DropTable("dbo.Familiar");
            RenameTable(name: "dbo.Moradores", newName: "Familiares");
        }
    }
}

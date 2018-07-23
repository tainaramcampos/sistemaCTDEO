namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remocao_tabela_responsavel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluno", "MaeCPF", "dbo.Responsavel");
            DropForeignKey("dbo.Aluno", "PaiCPF", "dbo.Responsavel");
            DropForeignKey("dbo.Aluno", "RespCPF", "dbo.Responsavel");
            DropIndex("dbo.Aluno", new[] { "MaeCPF" });
            DropIndex("dbo.Aluno", new[] { "PaiCPF" });
            DropIndex("dbo.Aluno", new[] { "RespCPF" });
            AddColumn("dbo.Aluno", "NomeMae", c => c.String());
            AddColumn("dbo.Aluno", "ProfissaoMae", c => c.String());
            AddColumn("dbo.Aluno", "NomePai", c => c.String());
            AddColumn("dbo.Aluno", "ProfissaoPai", c => c.String());
            AddColumn("dbo.Aluno", "ParentescoResp", c => c.String(nullable: false));
            AddColumn("dbo.Aluno", "NomeReponsavel", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "MaeCPF", c => c.String());
            AlterColumn("dbo.Aluno", "PaiCPF", c => c.String());
            AlterColumn("dbo.Aluno", "RespCPF", c => c.String());
            DropTable("dbo.Responsavel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        CPF = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Profissao = c.String(),
                        GraudeParentesco = c.String(),
                        TelefonesResponsavel = c.String(),
                    })
                .PrimaryKey(t => t.CPF);
            
            AlterColumn("dbo.Aluno", "RespCPF", c => c.String(maxLength: 128));
            AlterColumn("dbo.Aluno", "PaiCPF", c => c.String(maxLength: 128));
            AlterColumn("dbo.Aluno", "MaeCPF", c => c.String(maxLength: 128));
            DropColumn("dbo.Aluno", "NomeReponsavel");
            DropColumn("dbo.Aluno", "ParentescoResp");
            DropColumn("dbo.Aluno", "ProfissaoPai");
            DropColumn("dbo.Aluno", "NomePai");
            DropColumn("dbo.Aluno", "ProfissaoMae");
            DropColumn("dbo.Aluno", "NomeMae");
            CreateIndex("dbo.Aluno", "RespCPF");
            CreateIndex("dbo.Aluno", "PaiCPF");
            CreateIndex("dbo.Aluno", "MaeCPF");
            AddForeignKey("dbo.Aluno", "RespCPF", "dbo.Responsavel", "CPF");
            AddForeignKey("dbo.Aluno", "PaiCPF", "dbo.Responsavel", "CPF");
            AddForeignKey("dbo.Aluno", "MaeCPF", "dbo.Responsavel", "CPF");
        }
    }
}

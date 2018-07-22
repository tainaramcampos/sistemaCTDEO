namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Responsavel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "RespCPF", c => c.String(maxLength: 128));
            AddColumn("dbo.Responsavel", "GraudeParentesco", c => c.String());
            AddColumn("dbo.Responsavel", "TelefonesResponsavel", c => c.String());
            CreateIndex("dbo.Aluno", "RespCPF");
            AddForeignKey("dbo.Aluno", "RespCPF", "dbo.Responsavel", "CPF");
            DropColumn("dbo.Aluno", "TurmaId");
            DropColumn("dbo.Aluno", "NomeResponsavel");
            DropColumn("dbo.Aluno", "GraudeParentesco");
            DropColumn("dbo.Aluno", "TelefonesResponsavel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "TelefonesResponsavel", c => c.String());
            AddColumn("dbo.Aluno", "GraudeParentesco", c => c.String());
            AddColumn("dbo.Aluno", "NomeResponsavel", c => c.String());
            AddColumn("dbo.Aluno", "TurmaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Aluno", "RespCPF", "dbo.Responsavel");
            DropIndex("dbo.Aluno", new[] { "RespCPF" });
            DropColumn("dbo.Responsavel", "TelefonesResponsavel");
            DropColumn("dbo.Responsavel", "GraudeParentesco");
            DropColumn("dbo.Aluno", "RespCPF");
        }
    }
}

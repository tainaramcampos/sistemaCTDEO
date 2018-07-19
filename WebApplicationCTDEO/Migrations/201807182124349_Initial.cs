namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Genero = c.Int(nullable: false),
                        DatadeNascimento = c.DateTime(nullable: false),
                        Procedencia = c.Int(nullable: false),
                        CPF = c.String(),
                        RG = c.String(),
                        OrgaoExp = c.String(),
                        DatadeExp = c.DateTime(nullable: false),
                        Endereco = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Municipio = c.String(),
                        Comunidade = c.String(),
                        CEP = c.String(),
                        TelefoneResidencial = c.String(),
                        Celular = c.String(),
                        MaeCPF = c.String(maxLength: 128),
                        PaiCPF = c.String(maxLength: 128),
                        EscolhaResponsavel = c.Int(nullable: false),
                        GraudeParentesco = c.String(),
                        TelefonesResponsavel = c.String(),
                        InstituicaodeEnsino = c.String(),
                        RededeEnsino = c.Int(nullable: false),
                        CRE = c.String(),
                        BolsadeEstudos = c.Boolean(nullable: false),
                        TipodeInstituicao = c.Int(nullable: false),
                        Serie = c.String(),
                        Turno = c.Int(nullable: false),
                        Transporte = c.Int(nullable: false),
                        RegistroFed = c.String(),
                        TipodeBolsaAtleta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Responsavel", t => t.MaeCPF)
                .ForeignKey("dbo.Responsavel", t => t.PaiCPF)
                .Index(t => t.MaeCPF)
                .Index(t => t.PaiCPF);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        CPF = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Profissao = c.String(),
                    })
                .PrimaryKey(t => t.CPF);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        ModalidadeId = c.Int(nullable: false),
                        Dias = c.Int(nullable: false),
                        Horario = c.DateTime(nullable: false),
                        Aluno_AlunoId = c.Int(),
                    })
                .PrimaryKey(t => t.TurmaId)
                .ForeignKey("dbo.Modalidade", t => t.ModalidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno_AlunoId)
                .Index(t => t.ModalidadeId)
                .Index(t => t.Aluno_AlunoId);
            
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria = c.String(),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "Aluno_AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.Turma", "ModalidadeId", "dbo.Modalidade");
            DropForeignKey("dbo.Aluno", "PaiCPF", "dbo.Responsavel");
            DropForeignKey("dbo.Aluno", "MaeCPF", "dbo.Responsavel");
            DropIndex("dbo.Turma", new[] { "Aluno_AlunoId" });
            DropIndex("dbo.Turma", new[] { "ModalidadeId" });
            DropIndex("dbo.Aluno", new[] { "PaiCPF" });
            DropIndex("dbo.Aluno", new[] { "MaeCPF" });
            DropTable("dbo.Modalidade");
            DropTable("dbo.Turma");
            DropTable("dbo.Responsavel");
            DropTable("dbo.Aluno");
        }
    }
}

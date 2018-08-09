namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_dropdown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "RededeEnsino", c => c.Int());
            AlterColumn("dbo.Aluno", "SistemadeEnsino", c => c.Int());
            AlterColumn("dbo.AlunoSocial", "Sustento", c => c.Int());
            AlterColumn("dbo.AlunoSocial", "RendaMensal", c => c.Int());
            AlterColumn("dbo.AlunoSocial", "Residencia", c => c.Int());
            AlterColumn("dbo.AlunoSocial", "ComoConheceu", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AlunoSocial", "ComoConheceu", c => c.Int(nullable: false));
            AlterColumn("dbo.AlunoSocial", "Residencia", c => c.Int(nullable: false));
            AlterColumn("dbo.AlunoSocial", "RendaMensal", c => c.Int(nullable: false));
            AlterColumn("dbo.AlunoSocial", "Sustento", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluno", "SistemadeEnsino", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluno", "RededeEnsino", c => c.Int(nullable: false));
        }
    }
}

namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_nome_atributo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "RegiaoAdministrativa", c => c.String());
            AlterColumn("dbo.Aluno", "Celular", c => c.String(nullable: false));
            DropColumn("dbo.Aluno", "CRE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "CRE", c => c.String());
            AlterColumn("dbo.Aluno", "Celular", c => c.String());
            DropColumn("dbo.Aluno", "RegiaoAdministrativa");
        }
    }
}

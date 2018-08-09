namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_tipo_serie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Ano", c => c.Int());
            DropColumn("dbo.Aluno", "Serie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "Serie", c => c.String());
            DropColumn("dbo.Aluno", "Ano");
        }
    }
}

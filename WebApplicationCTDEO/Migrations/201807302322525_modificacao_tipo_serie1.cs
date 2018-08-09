namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_tipo_serie1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Serie", c => c.Int());
            DropColumn("dbo.Aluno", "Ano");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "Ano", c => c.Int());
            DropColumn("dbo.Aluno", "Serie");
        }
    }
}

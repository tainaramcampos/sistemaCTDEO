namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_nome_atributo1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Procedencia", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Procedencia", c => c.Int());
        }
    }
}

namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacao_de_tipo_propriedades2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Procedencia", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Procedencia", c => c.Int(nullable: false));
        }
    }
}

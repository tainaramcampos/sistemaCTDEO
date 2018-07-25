namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacao_de_tipo_propriedades1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "DatadeExp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "DatadeExp", c => c.DateTime(nullable: false));
        }
    }
}

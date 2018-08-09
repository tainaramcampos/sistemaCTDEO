namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_tipo_serie2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "CEP", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Turno", c => c.Int());
            AlterColumn("dbo.Aluno", "Transporte", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Transporte", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluno", "Turno", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluno", "CEP", c => c.String());
        }
    }
}

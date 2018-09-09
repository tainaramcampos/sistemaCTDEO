namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nao_mapear_id_de_turma : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Aluno", "IdsdeTurmas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "IdsdeTurmas", c => c.String());
        }
    }
}

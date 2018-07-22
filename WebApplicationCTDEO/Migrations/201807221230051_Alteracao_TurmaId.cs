namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_TurmaId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Turma", "Nome");
        }
    }
}

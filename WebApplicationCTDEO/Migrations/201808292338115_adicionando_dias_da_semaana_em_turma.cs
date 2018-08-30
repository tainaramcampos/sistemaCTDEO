namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionando_dias_da_semaana_em_turma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turma", "Dias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Turma", "Dias");
        }
    }
}

namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionando_dias_da_semaana_em_turma2 : DbMigration
    {
        public override void Up()
        {
          
        }

        public override void Down()
        {
            DropColumn("dbo.Turma", "Dias");
        }
    }
}

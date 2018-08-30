namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hora_para_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Turma", "Horario", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Turma", "Horario", c => c.DateTime(nullable: false));
        }
    }
}

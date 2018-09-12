namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numero_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Numero", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aluno", "Numero", c => c.Int(nullable: false));
        }
    }
}

namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tirando_generalizacao_da_modalidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Nivel = c.Int(nullable: false),
                        GrupoAtl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
            AddColumn("dbo.Turma", "ModalidadeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Turma", "ModalidadeId");
            AddForeignKey("dbo.Turma", "ModalidadeId", "dbo.Modalidade", "ModalidadeId", cascadeDelete: true);
            DropColumn("dbo.Turma", "Modalidade");
            DropColumn("dbo.Turma", "Nivel");
            DropColumn("dbo.Turma", "grupoAtl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Turma", "Dias", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "grupoAtl", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "Nivel", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "Modalidade", c => c.Int(nullable: false));
            DropForeignKey("dbo.Turma", "ModalidadeId", "dbo.Modalidade");
            DropIndex("dbo.Turma", new[] { "ModalidadeId" });
            DropColumn("dbo.Turma", "ModalidadeId");
            DropTable("dbo.Modalidade");
        }
    }
}

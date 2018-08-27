namespace WebApplicationCTDEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remocao_temporaria_de_modalidade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Turma", "ModalidadeId", "dbo.Modalidade");
            DropIndex("dbo.Turma", new[] { "ModalidadeId" });
            AddColumn("dbo.Turma", "Modalidade", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "Nivel", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "grupoAtl", c => c.Int(nullable: false));
            DropColumn("dbo.Turma", "ModalidadeId");
            DropTable("dbo.Modalidade");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NivelAtletismo = c.Int(),
                        Grupo = c.Int(),
                        NivelFutebol = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
            AddColumn("dbo.Turma", "ModalidadeId", c => c.Int(nullable: false));
            DropColumn("dbo.Turma", "grupoAtl");
            DropColumn("dbo.Turma", "Nivel");
            DropColumn("dbo.Turma", "Modalidade");
            CreateIndex("dbo.Turma", "ModalidadeId");
            AddForeignKey("dbo.Turma", "ModalidadeId", "dbo.Modalidade", "ModalidadeId", cascadeDelete: true);
        }
    }
}

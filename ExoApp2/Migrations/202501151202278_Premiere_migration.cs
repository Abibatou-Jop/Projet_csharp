namespace ExoApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Premiere_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        idC = c.Int(nullable: false, identity: true),
                        libelle = c.String(),
                    })
                .PrimaryKey(t => t.idC);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        idE = c.Int(nullable: false, identity: true),
                        prenom = c.String(),
                        nom = c.String(),
                        idClasse = c.Int(nullable: false),
                        classe_idC = c.Int(),
                    })
                .PrimaryKey(t => t.idE)
                .ForeignKey("dbo.Classes", t => t.classe_idC)
                .Index(t => t.classe_idC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "classe_idC", "dbo.Classes");
            DropIndex("dbo.Etudiants", new[] { "classe_idC" });
            DropTable("dbo.Etudiants");
            DropTable("dbo.Classes");
        }
    }
}

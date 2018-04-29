namespace DAB3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        adresseId = c.Int(nullable: false, identity: true),
                        by = c.String(),
                        land = c.String(),
                        postnummer = c.String(),
                        vejnavn = c.String(),
                        vejnummer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.adresseId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personId = c.Int(nullable: false, identity: true),
                        fornavn = c.String(),
                        mellemnavn = c.String(),
                        efternavn = c.String(),
                        email = c.String(),
                        type = c.String(),
                        primAdresse_adresseId = c.Int(),
                    })
                .PrimaryKey(t => t.personId)
                .ForeignKey("dbo.Adresses", t => t.primAdresse_adresseId)
                .Index(t => t.primAdresse_adresseId);
            
            CreateTable(
                "dbo.AlternativAdresses",
                c => new
                    {
                        altAdresseId = c.Int(nullable: false, identity: true),
                        by = c.String(),
                        land = c.String(),
                        postnummer = c.String(),
                        vejnavn = c.String(),
                        vejnummer = c.Int(nullable: false),
                        type = c.String(),
                        Person_personId = c.Int(),
                    })
                .PrimaryKey(t => t.altAdresseId)
                .ForeignKey("dbo.People", t => t.Person_personId)
                .Index(t => t.Person_personId);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        telefonId = c.Int(nullable: false, identity: true),
                        nummer = c.String(),
                        type = c.String(),
                        teleselskab = c.String(),
                        Person_personId = c.Int(),
                    })
                .PrimaryKey(t => t.telefonId)
                .ForeignKey("dbo.People", t => t.Person_personId)
                .Index(t => t.Person_personId);

            CreateTable(
                "dbo.__MigrationHistory2",
                c => new
                {
                    MigrationId = c.String(nullable: false, maxLength: 150),
                    ContextKey = c.String(nullable: false, maxLength: 300),
                    Model = c.Binary(nullable: false),
                    ProductVersion = c.String(nullable: false, maxLength: 32),
                })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses");
            DropForeignKey("dbo.Telefons", "Person_personId", "dbo.People");
            DropForeignKey("dbo.AlternativAdresses", "Person_personId", "dbo.People");
            DropIndex("dbo.Telefons", new[] { "Person_personId" });
            DropIndex("dbo.AlternativAdresses", new[] { "Person_personId" });
            DropIndex("dbo.People", new[] { "primAdresse_adresseId" });
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Telefons");
            DropTable("dbo.AlternativAdresses");
            DropTable("dbo.People");
            DropTable("dbo.Adresses");
        }
    }
}

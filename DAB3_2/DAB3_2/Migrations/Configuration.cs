namespace DAB3_2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAB3_2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DAB3_2.F184DABH2Gr3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAB3_2.F184DABH2Gr3Context context)
        {
            context.People.AddOrUpdate(x => x.personId,
                new People() { personId = 1,
                    fornavn = "Jane Austen",
                    Adresses = new Adresses(){adresseId = 1, by = "Aarhus", land = "Danmark", People = null, postnummer = "8000", vejnavn = "hejvej", vejnummer = 1},
                    AlternativAdresses = {new AlternativAdresses(){altAdresseId = 1, by = "hejby", land = "hejland", People = null, Person_personId = 1, postnummer = "1000", type = "hus", vejnavn = "hejmedvej", vejnummer = 9}},
                    efternavn = "efternavn",
                    email = "hejmail",
                    mellemnavn = "mellemnavn",
                    primAdresse_adresseId = 1,
                    Telefons = {new Telefons(){nummer = "88888888", People = null, Person_personId = 1, telefonId = 1, teleselskab = "tele", type = "mobil"}},
                    type = "ven"}
            );
        }
    }
}

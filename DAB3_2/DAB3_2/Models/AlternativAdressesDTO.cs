using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB3_2.Models
{
    public class AlternativAdressesDTO
    {
        public int altAdresseId { get; set; }

        public string by { get; set; }

        public string land { get; set; }

        public string postnummer { get; set; }

        public string vejnavn { get; set; }

        public int vejnummer { get; set; }

        public string type { get; set; }

        public int? Person_personId { get; set; }
        public PeopleDTO People { get; set; }

        public AlternativAdressesDTO()
        { }

        public AlternativAdressesDTO(AlternativAdresses altAdd)
        {
            altAdresseId = altAdd.altAdresseId;
            by = altAdd.by;
            land = altAdd.land;
            postnummer = altAdd.postnummer;
            vejnavn = altAdd.vejnavn;
            vejnummer = altAdd.vejnummer;
            type = altAdd.type;
            Person_personId = altAdd.Person_personId;
            People = new PeopleDTO(altAdd.People);
        }

    }
}
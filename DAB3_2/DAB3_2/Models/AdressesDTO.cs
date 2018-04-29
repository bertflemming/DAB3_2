using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB3_2.Models
{
    public class AdressesDTO
    {
        public int adresseId { get; set; }

        public string by { get; set; }

        public string land { get; set; }

        public string postnummer { get; set; }

        public string vejnavn { get; set; }

        public int vejnummer { get; set; }

        public AdressesDTO()
        { }

        public AdressesDTO(Adresses adresses)
        {
            adresseId = adresses.adresseId;
            by = adresses.by;
            land = adresses.land;
            postnummer = adresses.postnummer;
            vejnavn = adresses.vejnavn;
            vejnummer = adresses.vejnummer;
        }
    }
}
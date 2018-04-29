using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace DAB3_2.Models
{
    public class PeopleDTO
    {
        public int personId { get; set; }

        public string fornavn { get; set; }

        public string mellemnavn { get; set; }

        public string efternavn { get; set; }

        public string email { get; set; }

        public string type { get; set; }

        public int? primAdresse_adresseId { get; set; }

        public AdressesDTO AdressesDTO { get; set; }

        //public List<AlternativAdressesDTO> AlternativAdressesDTO { get; set; }

        //public List<TelefonsDTO> TelefonsDTO { get; set; }

        public PeopleDTO()
        {}
        public PeopleDTO(People person)
        {
            personId = person.personId;

            fornavn = person.fornavn;

            mellemnavn = person.mellemnavn;

            efternavn = person.efternavn;

            email = person.email;

            AdressesDTO = new AdressesDTO(person.Adresses);

            //AlternativAdressesDTO = new List<AlternativAdressesDTO>();

            //TelefonsDTO = new List<TelefonsDTO>();

            //foreach (AlternativAdresses aa in person.AlternativAdresses)
            //{
            //    AlternativAdressesDTO.Add(new AlternativAdressesDTO(aa));
            //}

            //foreach (Telefons t in person.Telefons)
            //{
            //    TelefonsDTO.Add(new TelefonsDTO(t));
            //}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB3_2.Models
{
    public class TelefonsDTO
    {
        public int telefonId { get; set; }

        public string nummer { get; set; }

        public string type { get; set; }

        public string teleselskab { get; set; }

        public int? Person_personId { get; set; }

        public PeopleDTO People { get; set; }
        public TelefonsDTO()
        { }

        public TelefonsDTO(Telefons tlf)
        {
            telefonId = tlf.telefonId;
            nummer = tlf.nummer;
            type = tlf.type;
            teleselskab = tlf.teleselskab;
            Person_personId = tlf.Person_personId;
            People = new PeopleDTO(tlf.People);
        }

    }
}
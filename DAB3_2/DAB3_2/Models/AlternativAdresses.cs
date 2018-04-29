namespace DAB3_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlternativAdresses
    {
        [Key]
        public int altAdresseId { get; set; }

        public string by { get; set; }

        public string land { get; set; }

        public string postnummer { get; set; }

        public string vejnavn { get; set; }

        public int vejnummer { get; set; }

        public string type { get; set; }

        public int? Person_personId { get; set; }

        public virtual People People { get; set; }
    }
}

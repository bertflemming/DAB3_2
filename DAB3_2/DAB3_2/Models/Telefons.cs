namespace DAB3_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Telefons
    {
        [Key]
        public int telefonId { get; set; }

        public string nummer { get; set; }

        public string type { get; set; }

        public string teleselskab { get; set; }

        public int? Person_personId { get; set; }

        public virtual People People { get; set; }
    }
}

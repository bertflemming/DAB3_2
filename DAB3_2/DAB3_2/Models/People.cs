namespace DAB3_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class People
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public People()
        {
            AlternativAdresses = new HashSet<AlternativAdresses>();
            Telefons = new HashSet<Telefons>();
        }

        [Key]
        public int personId { get; set; }

        public string fornavn { get; set; }

        public string mellemnavn { get; set; }

        public string efternavn { get; set; }

        public string email { get; set; }

        public string type { get; set; }

        public int? primAdresse_adresseId { get; set; }

        public virtual Adresses Adresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlternativAdresses> AlternativAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefons> Telefons { get; set; }
    }
}

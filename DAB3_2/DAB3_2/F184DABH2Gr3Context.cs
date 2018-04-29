namespace DAB3_2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class F184DABH2Gr3Context : DbContext
    {
        public F184DABH2Gr3Context()
            : base("name=F184DABH2Gr3Context")
        {
        }

        public virtual DbSet<C__MigrationHistory2> C__MigrationHistory { get; set; }
        public virtual DbSet<Adresses> Adresses { get; set; }
        public virtual DbSet<AlternativAdresses> AlternativAdresses { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Telefons> Telefons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresses>()
                .HasMany(e => e.People)
                .WithOptional(e => e.Adresses)
                .HasForeignKey(e => e.primAdresse_adresseId);

            modelBuilder.Entity<People>()
                .HasMany(e => e.AlternativAdresses)
                .WithOptional(e => e.People)
                .HasForeignKey(e => e.Person_personId);

            modelBuilder.Entity<People>()
                .HasMany(e => e.Telefons)
                .WithOptional(e => e.People)
                .HasForeignKey(e => e.Person_personId);
        }
    }
}

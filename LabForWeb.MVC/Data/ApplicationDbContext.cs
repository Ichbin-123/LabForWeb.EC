using LabForWeb.MVC.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabForWeb.MVC.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //
    // public DbSet<Utente> Utenti => Set<Utente>(); // Abbiamo adesso ApplicationUser.cs
    public DbSet<Prodotto> Prodotti => Set<Prodotto>();
    // public DbSet<PartitaIVA> PartitaIVAs => Set<PartitaIVA>();
    public DbSet<OrdineDettaglio> OrdineDettagli => Set<OrdineDettaglio>();
    public DbSet<Ordine> Ordini => Set<Ordine>();
    public DbSet<Indirizzo> Indirizzi => Set<Indirizzo>();
    public DbSet<Categoria> Categorie => Set<Categoria>();

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=eCommerce");
    //    }
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Utente>()
        //    .HasData(
        //        new Utente
        //        {
        //            Id =2,
        //            Nome = "Admin",
        //            Cognome = "Admin",
        //            Email = "admin@admin.com",

        //            CodiceFiscale = "",
        //            Telefono = "",
        //            NotificheWA = true
        //        }
        //    );

        //modelBuilder.Entity<Categoria>()
        //    .HasData(
        //            new Categoria
        //            {
        //                Id = 1,
        //                Nome = "Articoli Sportivi"
        //            },
        //            new Categoria
        //            {
        //                Id = 2,
        //                Nome = "Elettromestici"
        //            },
        //            new Categoria
        //            {
        //                Id = 3,
        //                Nome = "Abbigliamento per la coppia"
        //            }
        //    );



        //modelBuilder.Entity<ApplicationUser>(entity => // modelBuilder.Entity<Utente>(entity
        //{
        //    entity.HasKey(e => e.Id); // PK tabella Utente
        //    entity.Property(e => e.Id)
        //            .IsRequired();
        //    entity.Property(e => e.Id)
        //            .ValueGeneratedOnAdd();

        //    entity.HasIndex(e => e.Cognome); // Indice su Cognome non unico

        //});

        //modelBuilder.Entity<PartitaIVA>(entity =>
        //    {
        //        entity.HasOne(e => e.Utente) //  entity.HasOne(e => e.Utente)
        //               .WithOne(u => u.PartitaIVA)
        //               .HasForeignKey<PartitaIVA>(e => e.Id);

        //        entity.Property(e => e.Id)
        //              .IsRequired();

        //        entity.HasIndex(e => e.NumeroPIVA).IsUnique(); // Indice su PartitaIVA unico
        //    });

        modelBuilder.Entity<Indirizzo>(entity =>
        {
            entity.HasOne(e => e.Utente)
                  .WithMany(u => u.Indirizzi)
                  .HasForeignKey(e => e.UtenteId);

            entity.Property(e => e.CAP)
                  .IsRequired();

            entity.HasIndex(e => e.CAP);  // Indice su CAP non unico
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasOne(e => e.Indirizzo)
                  .WithMany(i => i.Ordini)
                  .HasForeignKey(e => e.IndirizzoId);

            entity.HasIndex(e => e.Stato);

            entity.HasIndex(e => new { e.Numero, e.Anno }).IsUnique();

            entity.HasIndex(e => e.Data);

        });

        modelBuilder.Entity<OrdineDettaglio>(entity =>
        {
            entity.HasOne(e => e.Ordine)
                  .WithMany(d => d.Dettagli)
                  .HasForeignKey(e => e.OrdineId);

            entity.HasOne(e => e.Prodotto)
                  .WithMany(p => p.OrdineDettagli)
                  .HasForeignKey(e => e.ProdottoId);

            entity.HasIndex(e => new { e.OrdineId, e.ProdottoId }).IsUnique();

            entity.HasIndex(e => e.ProdottoId);
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {

            entity.HasIndex(e => e.Visibile);

            entity.HasIndex(e => e.Attivo);

            entity.HasMany(e => e.Categorie)
                  .WithMany(c => c.Prodotti);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasIndex(e => e.Nome).IsUnique();

            entity.HasMany(e => e.Prodotti)
                  .WithMany(p => p.Categorie);
        });

    }



    //


}

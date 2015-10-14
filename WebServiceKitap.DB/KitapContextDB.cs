using WebServiceKitap.DB.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebServiceKitap.DB
{
    public class KitapContextDB : IdentityDbContext<Usuario>
    {
        public KitapContextDB()
            : base("KitapConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.PhoneNumber)
                .HasColumnName("Telefone");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .Property(p => p.PhoneNumber)
                .HasColumnName("Telefone");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuarioPapel");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("Logins");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Papeis");
        }
    }
}

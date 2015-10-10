namespace WebServiceKitap.DB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    internal sealed class Configuration : DbMigrationsConfiguration<WebServiceKitap.DB.KitapContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebServiceKitap.DB.KitapContextDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categorias.AddOrUpdate(c => c.Id,
                new Categoria("Administra��o e Neg�cios"),
                new Categoria("Agropecu�ria"),
                new Categoria("Animais de Estima��o"),
                new Categoria("Arquitetura e Decora��o"),
                new Categoria("Artes"),
                new Categoria("�udio Livros"),
                new Categoria("Autoajuda e Reflex�o"),
                new Categoria("Bem Estar e Lazer"),
                new Categoria("Biografia"),
                new Categoria("Ci�ncias Biol�gicas e Naturais"),
                new Categoria("Ci�ncias Exatas"),
                new Categoria("Ci�ncias Humanas e Socias"),
                new Categoria("Comunica��o e Linguistica"),
                new Categoria("Concursos"),
                new Categoria("Culin�ria e Gastronomia"),
                new Categoria("Dicion�rios"),
                new Categoria("Did�ticos e Educa��o"),
                new Categoria("Direito"),
                new Categoria("Economia"),
                new Categoria("Engenharia"),
                new Categoria("Ensino de Linguas Estrangeiras"),
                new Categoria("Esoterismo"),
                new Categoria("Esportes"),
                new Categoria("Filosofia"),
                new Categoria("Hist�ria e Geografia"),
                new Categoria("Hist�ria em Quadrinhos"),
                new Categoria("Livro Infantil"),
                new Categoria("Inform�tica"),
                new Categoria("Juvenil"),
                new Categoria("Literatura Estrangeira"),
                new Categoria("Literatura Nacional"),
                new Categoria("Livros Importados"),
                new Categoria("Medicina e Sa�de"),
                new Categoria("Moda e Beleza"),
                new Categoria("Psicologia"),
                new Categoria("Religi�o"),
                new Categoria("Turismo"));
        }
    }
}

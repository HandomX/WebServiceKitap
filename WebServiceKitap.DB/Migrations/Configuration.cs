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
                new Categoria("Administração e Negócios"),
                new Categoria("Agropecuária"),
                new Categoria("Animais de Estimação"),
                new Categoria("Arquitetura e Decoração"),
                new Categoria("Artes"),
                new Categoria("Áudio Livros"),
                new Categoria("Autoajuda e Reflexão"),
                new Categoria("Bem Estar e Lazer"),
                new Categoria("Biografia"),
                new Categoria("Ciências Biológicas e Naturais"),
                new Categoria("Ciências Exatas"),
                new Categoria("Ciências Humanas e Socias"),
                new Categoria("Comunicação e Linguistica"),
                new Categoria("Concursos"),
                new Categoria("Culinária e Gastronomia"),
                new Categoria("Dicionários"),
                new Categoria("Didáticos e Educação"),
                new Categoria("Direito"),
                new Categoria("Economia"),
                new Categoria("Engenharia"),
                new Categoria("Ensino de Linguas Estrangeiras"),
                new Categoria("Esoterismo"),
                new Categoria("Esportes"),
                new Categoria("Filosofia"),
                new Categoria("História e Geografia"),
                new Categoria("História em Quadrinhos"),
                new Categoria("Livro Infantil"),
                new Categoria("Informática"),
                new Categoria("Juvenil"),
                new Categoria("Literatura Estrangeira"),
                new Categoria("Literatura Nacional"),
                new Categoria("Livros Importados"),
                new Categoria("Medicina e Saúde"),
                new Categoria("Moda e Beleza"),
                new Categoria("Psicologia"),
                new Categoria("Religião"),
                new Categoria("Turismo"));
        }
    }
}

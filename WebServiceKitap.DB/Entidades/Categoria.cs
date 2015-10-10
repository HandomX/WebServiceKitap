using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.DB.Entidades
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }

        public Categoria() { }
        public Categoria(string nome) { this.Nome = nome; }
    }
}

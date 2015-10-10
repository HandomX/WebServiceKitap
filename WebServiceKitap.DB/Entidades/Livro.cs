using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.DB.Entidades
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public long Id { get; set; }
        public string ImagemLink { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autores { get; set; }
        [Required]
        public string Editora { get; set; }
        [Required]
        [Index("Isbn", IsUnique=true)]
        public string Isbn { get; set; }

        [Required]
        public int NumeroDePaginas { get; set; }

        public string Descricao{get; set; }
        [Required]
        public int AnoDePublicacao { get; set; }
        [Required]
        public string Status { get; set; }

        [Required]
        public long CategoriaID{get;set;}
        
        [ForeignKey("CategoriaID")]
        public Categoria Categoria{get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.ViewModels
{
    public class LivroModel
    {
        public string ImageLink { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string[] Autores { get; set; }
        [Required]
        public string Editora { get; set; }
        [Required]
        
        public string[] Isbn { get; set; }

        [Required]
        public int NumeroDePaginas { get; set; }

        public string Descricao { get; set; }
        [Required]
        public int AnoDePublicacao { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public CategoriaModel Categoria { get; set; }
    }
}

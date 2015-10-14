using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.DB.Entidades
{
    
    public class Usuario : IdentityUser
    {
        public string ImageLink { get; set; }
        public string Nome { get; set; }
    }
}

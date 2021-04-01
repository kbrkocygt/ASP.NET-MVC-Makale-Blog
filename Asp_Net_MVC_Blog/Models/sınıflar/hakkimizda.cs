using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    public class hakkimizda
    { 
        [Key]
        public int id { get; set; }
        public string resim { get; set; }
        public  string aciklama { get; set; }
    }
}
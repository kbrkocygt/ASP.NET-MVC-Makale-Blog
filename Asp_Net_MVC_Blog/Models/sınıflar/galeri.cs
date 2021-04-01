using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{[Table("galeri")]
    public class galeri
    {[Key]
        public int galeriİD { get; set; }
        public string  Rbaslik { get; set; }
       
        [DisplayName("Resim ")]
        public string Ryolu { get; set; }
      
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    public class iletisim
    {  [Key]

        public int id { get; set; }
        public string adres { get; set; }
        public string mail { get; set; }
       public string telefon { get; set; }
        public string fax { get; set; }
    }
}
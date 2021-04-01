using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    [Table("Yorumlar")]
    public class yorum
    {[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumId { get; set; }

        [Required(ErrorMessage = "Lütfen yorumunuzu giriniz.")]
        public string Icerik { get; set; }
        public bool onay { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcıadınızı giriniz.")]
        public string kullaniciadi { get; set; }

       
       
        public int? Mid { get; set; }
        public  makale Makale { get; set; }
       
        
    }
}
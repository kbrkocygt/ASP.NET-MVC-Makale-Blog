using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    [Table("Admin")]
    public class admin
    {
        [Key] //id 
        public int ID { get; set; }
        [Required,StringLength(50,ErrorMessage = "Lütfen kullanıcı adınızı giriniz.(50 karakter olmalıdır)")]
        public string Kullaniciadi { get; set; }
        [Required,StringLength(20, ErrorMessage = "Lütfen şifrenizi giriniz.(20 karakter olmalıdır")]
        public string Sifre { get; set; }

        public string yetki { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    [Table("uye")]
    public class uye
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //id foreıgn key belirttik
        public int Uid { get; set; }
      
        [Required ,StringLength(50, ErrorMessage = "Lütfen adınızı giriniz.(En fazla 50 karakter olmalıdır)")]
        public string Uyead { get; set; }
    
        [Required, StringLength(50, ErrorMessage = "Lütfen soyadınızı giriniz.(En fazla 50 karakter olmalıdır)")]
        public string Uyesoyad { get; set; }
        
        [Required, StringLength(50, ErrorMessage = "Lütfen kullanıcı adınızı giriniz.(En fazla 50 karakter olmalıdır)")]
        public string Ukullaniciadi { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string Usifre { get; set; }
        
      
    }
}
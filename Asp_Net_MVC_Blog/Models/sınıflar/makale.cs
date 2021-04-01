using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    [Table("makale")]
    public class makale
    {

        [Key] //id belirttik

        public int Mid { get; set; }
        [Required(ErrorMessage = "Lütfen makalenin başlığını giriniz.")]
        public string Mbaslik { get; set; }
        [Required(ErrorMessage = "Lütfen makale özetini  giriniz.")]
        public string Mözet { get; set; }
        [Required(ErrorMessage = "Lütfen makale içeriğini  giriniz.")]
        public string Micerik { get; set; }
        
        [Required(ErrorMessage = "Lütfen makalenin eklenme tarihini giriniz.")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen üye olma tarihini, doğru bir şekilde giriniz.")]
        public DateTime Mtarih { get; set; }
        public string Mresim { get; set; }
        //her makale bır kategorıye aıttır
        public int? Kid { get; set; }
        public kategori kategori { get; set; } //Bir blog bir kategoriye aittir 
        //kategori nesnesinde bir kategori içeriyor
        public ICollection<yorum> yorum { get; set; }
    }
}
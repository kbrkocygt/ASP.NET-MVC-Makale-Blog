using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    [Table("kategori")]
    public class kategori
    {
        [Key] //id belirttik

        public int Kid { get; set; }
        [StringLength(50), Required]
        public string Kadi { get; set; }
       
        public string Kadet { get; set; }

        public  ICollection <makale> makales { get; set; } //icollection turunde bir liste içericek bu listede makaleyi tututar. bu da bize bireçok ilişkiyi saglar


    }
}
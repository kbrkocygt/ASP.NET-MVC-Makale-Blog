using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp_Net_MVC_Blog.Models.sınıflar
{
    public class Contex:DbContext  //dbcontex den miras aldık
    {//Tabloların  veri tabanına  set işlemi
       

        public DbSet<makale> makale { get; set; }
        public DbSet<uye> uye { get; set; } 
        public DbSet<kategori> kategori { get; set; }
        public DbSet<yorum> yorum { get; set; }
        public DbSet<admin> admin { get; set; }
        public DbSet<galeri> galeri { get; set; }
        public DbSet<hakkimizda> hakkimizda { get; set; }
        public DbSet<iletisim> iletisim { get; set; }
        


    }
}
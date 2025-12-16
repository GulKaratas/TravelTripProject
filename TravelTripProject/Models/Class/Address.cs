using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Class
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Aciklama { get; set; }
        public string Konum { get; set; }
    }
}
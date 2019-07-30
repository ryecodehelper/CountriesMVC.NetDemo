namespace CountriesMVC.NETDemo.DAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int? Population { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}

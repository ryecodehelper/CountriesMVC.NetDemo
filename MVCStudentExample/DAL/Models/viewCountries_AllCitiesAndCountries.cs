namespace CountriesMVC.NETDemo.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class viewCountries_AllCitiesAndCountries
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CityName { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Latitude { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Longitude { get; set; }

        public int? Population { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }

        [Key]
        [Column(Order = 5)]
        public string CountryName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(2)]
        public string ISO2 { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(3)]
        public string ISO3 { get; set; }
    }
}

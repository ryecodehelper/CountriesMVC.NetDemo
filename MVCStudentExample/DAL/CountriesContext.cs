namespace CountriesMVC.NETDemo.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class CountriesContext : DbContext
    {
        public CountriesContext()
            : base("name=CountriesContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<viewCountries_AllCitiesAndCountries> viewCountries_AllCitiesAndCountries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<City>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ISO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.ISO3)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.ISO2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<viewCountries_AllCitiesAndCountries>()
                .Property(e => e.ISO3)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

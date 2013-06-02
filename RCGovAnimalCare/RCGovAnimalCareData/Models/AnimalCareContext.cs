using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RCGovAnimalCareData.Models.Mapping;

namespace RCGovAnimalCareData.Models
{
    public partial class AnimalCareContext : DbContext
    {
        static AnimalCareContext()
        {
            Database.SetInitializer<AnimalCareContext>(null);
        }

        public AnimalCareContext()
            : base("Name=AnimalCareContext")
        {
        }

        public DbSet<AnimalPickup> AnimalPickups { get; set; }
        public DbSet<Citation> Citations { get; set; }
        public DbSet<dtproperty> dtproperties { get; set; }
        public DbSet<lstAnimalBreed> lstAnimalBreeds { get; set; }
        public DbSet<lstAnimalColor> lstAnimalColors { get; set; }
        public DbSet<lstAnimalSex> lstAnimalSexes { get; set; }
        public DbSet<lstAnimalSize> lstAnimalSizes { get; set; }
        public DbSet<lstAnimalType> lstAnimalTypes { get; set; }
        public DbSet<lstCity> lstCities { get; set; }
        public DbSet<lstFacility> lstFacilities { get; set; }
        public DbSet<lstMagistrate> lstMagistrates { get; set; }
        public DbSet<lstOfficer> lstOfficers { get; set; }
        public DbSet<lstOrdinance> lstOrdinances { get; set; }
        public DbSet<lstRace> lstRaces { get; set; }
        public DbSet<lstReport> lstReports { get; set; }
        public DbSet<lstState> lstStates { get; set; }
        public DbSet<lstStatu> lstStatus { get; set; }
        public DbSet<lstTable> lstTables { get; set; }
        public DbSet<lstTableAssist> lstTableAssists { get; set; }
        public DbSet<lstText> lstTexts { get; set; }
        public DbSet<lstUser> lstUsers { get; set; }
        public DbSet<lstZone> lstZones { get; set; }
        public DbSet<Offender> Offenders { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<v_Citations> v_Citations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnimalPickupMap());
            modelBuilder.Configurations.Add(new CitationMap());
            modelBuilder.Configurations.Add(new dtpropertyMap());
            modelBuilder.Configurations.Add(new lstAnimalBreedMap());
            modelBuilder.Configurations.Add(new lstAnimalColorMap());
            modelBuilder.Configurations.Add(new lstAnimalSexMap());
            modelBuilder.Configurations.Add(new lstAnimalSizeMap());
            modelBuilder.Configurations.Add(new lstAnimalTypeMap());
            modelBuilder.Configurations.Add(new lstCityMap());
            modelBuilder.Configurations.Add(new lstFacilityMap());
            modelBuilder.Configurations.Add(new lstMagistrateMap());
            modelBuilder.Configurations.Add(new lstOfficerMap());
            modelBuilder.Configurations.Add(new lstOrdinanceMap());
            modelBuilder.Configurations.Add(new lstRaceMap());
            modelBuilder.Configurations.Add(new lstReportMap());
            modelBuilder.Configurations.Add(new lstStateMap());
            modelBuilder.Configurations.Add(new lstStatuMap());
            modelBuilder.Configurations.Add(new lstTableMap());
            modelBuilder.Configurations.Add(new lstTableAssistMap());
            modelBuilder.Configurations.Add(new lstTextMap());
            modelBuilder.Configurations.Add(new lstUserMap());
            modelBuilder.Configurations.Add(new lstZoneMap());
            modelBuilder.Configurations.Add(new OffenderMap());
            modelBuilder.Configurations.Add(new OwnerMap());
            modelBuilder.Configurations.Add(new v_CitationsMap());
        }
    }
}

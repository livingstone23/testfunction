using Microsoft.EntityFrameworkCore;
using SHM.Domain.Models.dbo;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0106;
using SHM.Domain.Models.Sahc0108;
using SHM.Domain.Models.Sahc0109;

namespace SHM.Function.Data;

public class FunctionDbContext : DbContext
{

    public FunctionDbContext()
    {
    }

    public FunctionDbContext(DbContextOptions<FunctionDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }


    #region RegionCatalogos

    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Province> Provinces { get; set; }
    
    public DbSet<District> Districts { get; set; }
    
    public DbSet<Township> TownShips { get; set; }
    
    public DbSet<CivilStatus> CivilStatus { get; set; }

    public DbSet<RelationshipType> Relationships { get; set; }

    public DbSet<LanguageCode> LanguageCodes { get; set; }

    public DbSet<TranslationCatalog> TranslationCatalogs { get; set; }

    public DbSet<UserTemp> UserTemps { get; set; }

    #endregion


    #region RegionTransaccionales

    //public DbSet<MasterCreditItem> MasterCreditItems { get; set; }

    //public DbSet<MasterCreditItemAddress> MasterCreditItemAddress { get; set; }

    //public DbSet<MasterCreditItemWorkingInformation> MasterCreditItemWorkingInformations { get; set; }

    //public DbSet<MasterCreditItemMaritalInformation> MasterCreditItemMaritalInformation { get; set; }

    //public DbSet<MasterCreditItemPersonalReference> MasterCreditItemPersonalReferences { get; set; }

    //public DbSet<MasterCreditItemAdditionalCard> MasterCreditItemAdditionalCards { get; set; }

    public DbSet<EntityMasterGeneral> EntityMasterGenerals { get; set; }

    public DbSet<EntityMasterAddress> EntityMasterAddress { get; set; }
    public DbSet<EntityMasterGroup> EntityMasterGroups { get; set; }

    //public DbSet<OnBoarding> OnBoardings { get; set; }
    //public DbSet<OnBoardingAdditionalCard> OnBoardingAdditionalCards { get; set; }
    //public DbSet<OnBoardingAddress> OnBoardingAddress { get; set; }
    //public DbSet<OnBoardingMaritalInformation> OnBoardingMaritalInformations { get; set; }
    //public DbSet<MasterCreditItemPersonalReference> OnBoardingPersonalReferences { get; set; }
    //public DbSet<OnBoardingWorkingInformation> OnBoardingWorkingInformation { get; set; }

    #endregion



    #region Sahc0106
    
    
    public DbSet<EntityMasterGeneralPLCC> EntityMasterGeneralPLCC { get; set; }


    public DbSet<CreditCardStatus> CreditCardStatus { get; set; }


    public DbSet<CreditCardMasterStatus> CreditCardMasterStatus { get; set; }


    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EntityMasterGeneral>(entity =>
        {
            entity.HasKey(c => c.EntityMasterGeneralKey);
        });

        modelBuilder.Entity<EntityMasterAddress>(entity =>
        {
            entity.HasKey(c => c.EntityMasterAddressKey);
        });

        //modelBuilder.Entity<CivilStatus>(entity =>
        //{
        //    entity.HasKey(c => c.CivilStatusKey);
        //});

        //modelBuilder.Entity<RelationshipType>(entity =>
        //{
        //    entity.HasKey(c => c.RelationshipTypeKey);
        //});

        //modelBuilder.Entity<Country>(entity =>
        //{
        //    entity.HasKey(c => c.CountryKey);
        //});

        //modelBuilder.Entity<Province>(entity =>
        //{
        //    entity.HasKey(c => c.ProvinceKey);
        //});

        //modelBuilder.Entity<District>(entity =>
        //{
        //    entity.HasKey(c => c.DistrictKey);
        //});

        //modelBuilder.Entity<MasterCreditItem>(entity =>
        //{
        //    entity.HasKey(c => c.MasterCreditItemKey);
        //});

        //modelBuilder.Entity<MasterCreditItemAddress>(entity =>
        //{
        //    entity.HasKey(c => c.MasterCreditItemAddressKey);
        //});

        //modelBuilder.Entity<MasterCreditItemWorkingInformation>(entity =>
        //{
        //    entity.HasKey(c => c.MasterWorkingInformationKey);
        //});

        //modelBuilder.Entity<MasterCreditItemMaritalInformation>(entity =>
        //{
        //    entity.HasKey(c => c.MasterCreditItemMaritalInformationKey);
        //});

        //modelBuilder.Entity<MasterCreditItemPersonalReference>(entity =>
        //{
        //    entity.HasKey(c => c.MasterCreditItemPersonalReferenceKey);
        //});

        //modelBuilder.Entity<MasterCreditItemPersonalReference>(entity =>
        //{
        //    entity.HasKey(c => c.MasterCreditItemPersonalReferenceKey);
        //});

    }

}


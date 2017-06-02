/*
 * this is Db context class here we attach the database name to the  DataBaseContext class
 */
using InvestmentDataModel.DataModel;
using System.Data.Entity;

namespace InvestmentDataModel
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("InvestmentTracker")
        {
            Database.SetInitializer<DataBaseContext>(new CreateDatabaseIfNotExists<DataBaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserAccountDetail> UserAccountDetail { get; set; }
        public DbSet<LoanType> LoanType { get; set; }
        public DbSet<LoanLeadInformation> LoanLeadInformation { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}

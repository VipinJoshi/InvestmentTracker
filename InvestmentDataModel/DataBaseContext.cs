/*
 * this is Db context class here we attach the database name to the  DataBaseContext class
 */
using InvestmentDataModel.DataModel;
using System.Data.Entity;

namespace InvestmentDataModel
{
    public  class DataBaseContext:DbContext
    {
        public DataBaseContext():base("InvestmentTracker")
        {
            Database.SetInitializer<DataBaseContext>(new CreateDatabaseIfNotExists<DataBaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public  DbSet<UserLogin> UserLogin { get; set; }
        public  DbSet<UserAccountDetail> UserAccountDetail { get; set; }
    }
}

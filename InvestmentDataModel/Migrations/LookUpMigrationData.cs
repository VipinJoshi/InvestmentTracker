/*
 * this is the migration script for lookup data 
 */
using InvestmentDataModel.DataModel;
using System.Data.Entity.Migrations;

namespace InvestmentDataModel.Migrations
{
    public class LookUpMigrationData
    {
        public void LoanTypeData(DataBaseContext context)
        {
            context.LoanType.AddOrUpdate(
                l => l.LoanTypeName,
                new LoanType { LoanTypeName = "Car Loan" ,Active=true},
                new LoanType { LoanTypeName = "Home Loan" , Active = true },
                new LoanType { LoanTypeName = "Education Loan", Active = true },
                new LoanType { LoanTypeName = "Personal Loan", Active = true }
                );
        }

        public void RoleData(DataBaseContext context)
        {
            context.Role.AddOrUpdate(l => l.RoleName,
                new Role { RoleName = "admin", Active = true },
                new Role { RoleName = "normal", Active = true }
                );
        }
    }
}

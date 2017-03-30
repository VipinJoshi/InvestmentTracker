/*
 * Unit of work class file is used to implement the logic to save the chanes in db 
 * assign  repository to the object and 
 * method to dispose the object
 */
using System;
using System.Collections.Generic;
using InvestmentDataModel.GenericRepository;
using System.Diagnostics;
using System.Data.Entity.Validation;
using InvestmentDataModel.Interface;
using InvestmentDataModel.IRepository;
using InvestmentDataModel.DataModel;
using InvestmentDataModel;

namespace DataModel.UnitOfWork
{
   public  class UnitOfWork: IUnitOfWork
    {
        #region Private member variables...

        private DataBaseContext context = null;
        private bool disposed = false;

        public UnitOfWork()
        {
            context = new DataBaseContext();
        }

        GenericRepository<UserLogin, DataBaseContext> _userRepository;

        #endregion

        #region properties
       

        public IGenericRepository<UserLogin> UsersLogin
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new GenericRepository<UserLogin, DataBaseContext>(context);

                return _userRepository;

            }
        }

        public IGenericRepository<UserAccountDetail> UsersAccountDetail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion


        #region Methods
        /// <summary>
        /// this class is used to save the changes in db
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            try
            {
                return context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }
        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

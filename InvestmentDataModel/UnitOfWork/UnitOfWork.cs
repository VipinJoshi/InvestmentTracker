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

        public UnitOfWork()
        {
            context = new DataBaseContext();
        }

        GenericRepository<UserLogin, DataBaseContext> _userRepository;

        //private GenericRepository<userslogin> _userRepository;
        //private GenericRepository<useraccountdetail, context> _productRepository;
        //private GenericRepository<useraccountdetail,context> _tokenRepository;//change later
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                context.SaveChanges();
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
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);//todo: change the path

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;

      

        

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
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            this.disposed = true;
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentDataModel.IRepository
{
    public interface IGenericRepository<TEntity>
    {

       

        IEnumerable<TEntity> Get();//to get all the data


        TEntity GetByID(object id);

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);


        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);


        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);


        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TEntity entityToUpdate);


        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);


        TEntity Get(Func<TEntity, Boolean> where);

        void Delete(Func<TEntity, Boolean> where);


        IEnumerable<TEntity> GetAll()       ;

        IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity,
            bool>> predicate, params string[] include);


        bool Exists(object primaryKey);


        TEntity GetSingle(Func<TEntity, bool> predicate);

        TEntity GetFirst(Func<TEntity, bool> predicate);

        TEntity FindRecord(Func<TEntity, bool> predicate);

    }
}

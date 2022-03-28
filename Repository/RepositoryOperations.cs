using DomainLayer;
using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class RepositoryOperations<T> : IRepositoryOperations<T> where T:class
    {
        private readonly ILog _log;
        DbContext Context;
        readonly DbSet<T> dbSet;
        IEnumerable<T> entities;
        T entity;
       
        public RepositoryOperations(DbContext product)
        {
            _log = LogManager.GetLogger(typeof(RepositoryOperations<T>));
            Context = product;
            dbSet = Context.Set<T>();
           
        }
        public void Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }
            
        }

        public IEnumerable<T> Get()
        {
            try
            {
                entities = dbSet.ToList();
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }
            return entities;
        }

        public T GetById(int Id)
        {
            try
            {
                entity = dbSet.Find(Id);
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }

            return entity;
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }
            
        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw ex;
            }
            
        }
    }
}

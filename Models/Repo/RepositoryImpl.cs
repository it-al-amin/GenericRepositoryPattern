using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryPattern.Models.Repo
{
    public class RepositoryImpl<T>: IRepository<T> where T :class
    {
        private DataContext context;
        private IDbSet<T> dbEntity;
        public RepositoryImpl()
        {
            context = new DataContext();
            dbEntity = context.Set<T>();
        }
        public void DeleteModel(int ModelId)
        {
           T model=dbEntity.Find(ModelId);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetModel()
        {

            return dbEntity.ToList();
        }

        public T GetModelById(int ModelId)
        {
            return dbEntity.Find(ModelId);
        }

        public void InsertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void Save()
        {
          context.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
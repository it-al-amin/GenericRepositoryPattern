using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Models.Repo
{
   public interface IRepository<T> where T:class//define a generic interface
    {
        IEnumerable<T> GetModel();
        T GetModelById(int ModelId);
        void InsertModel(T model);
        void DeleteModel(int ModelId);
        void UpdateModel(T model);
        void Save();
        
    }
}

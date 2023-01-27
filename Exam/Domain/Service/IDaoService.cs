using Exam.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Service
{
    internal interface IDaoService<T> where T : EntityBase
    {
        Task<T> Create(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}

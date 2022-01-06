using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface IService<TModel> : IDisposable
    {
        public void Create(TModel model);

        public void Delete(int id);
    }
}

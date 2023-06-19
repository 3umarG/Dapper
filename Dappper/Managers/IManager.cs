using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dappper.Managers
{
    public interface IManager<T>
    {
        List<T> GetAll();

        public bool Add(Product product);

        public bool Remove(long ID);

        public bool Update(Product product);

        public T GetByID(long ID);


    }
}

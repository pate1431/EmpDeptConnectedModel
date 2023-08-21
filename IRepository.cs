using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repositories
{
    public interface IRepository<T>
    {
        bool createRow(T entity);
        IEnumerable<T> readAllRows();
        T ReadRowById(int id);
        bool UpdateRow(T entity);
        bool DeleteRow(T entity);
        bool DeleteRow(int id);

    }
}

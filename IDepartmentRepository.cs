using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;

namespace Repositories
{

    public interface IDepartmentRepository: IRepository<Department>
    {
        Department ReadRowByName(string name);
    }
}

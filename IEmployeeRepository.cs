﻿using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        void ReadRowByName(string firstName, string lastName); 
    }
}

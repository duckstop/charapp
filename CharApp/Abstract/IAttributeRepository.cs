using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharApp.Abstract
{
    internal interface IAttributeRepository<T> //Generic interface der bruges til at beskrive alle character attribues repositories og disses operationer.
    {
        List<T> GetAll();
        T Find(int id);
    }
}

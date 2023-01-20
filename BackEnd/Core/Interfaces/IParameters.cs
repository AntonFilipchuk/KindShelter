using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IParameters
    {
        const int MaxPageSize = 50;
        int PageIndex {get;}
        int PageSize {get;}
    }
}
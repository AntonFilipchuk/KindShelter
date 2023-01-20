using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace Core.Helpers
{
    public class DataForPagination<T> where T : BaseEntity
    {
        public DataForPagination(int numberOfSpecifiedObjectsInDB, IEnumerable<T>? objectList)
        {
            NumberOfObjectsInDB = numberOfSpecifiedObjectsInDB;
            ObjectList = objectList;
        }

        public DataForPagination(T? singleObject)
        {
            SingleObject = singleObject;
        }

        public int NumberOfObjectsInDB { get; private set; }
        public IEnumerable<T>? ObjectList { get; private set; }
        public T? SingleObject { get; private set; }
    }
}

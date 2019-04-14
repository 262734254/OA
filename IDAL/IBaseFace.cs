using System.Collections.Generic;

namespace IDAL
{
    public interface IBaseFace
    {
        int Add(object obj);

        int Update(object obj);

        int Delete(int id);

        object Get(int id);
    }
}

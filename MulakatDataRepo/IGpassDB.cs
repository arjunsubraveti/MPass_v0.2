using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MulakatEntities;

namespace MulakatDataOps
{
    public interface IGpassDB
    {
        int InsertGPassDB(GpassEntity gpassEntity);

        long RetrieveSerialNumber();

    }
}

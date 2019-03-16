using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据访问操作类型
    /// </summary>
    public enum DataAccessOpType : int
    {
        Q = 0,
        U = 1,
        I = 2,
        D = 3
    }
}

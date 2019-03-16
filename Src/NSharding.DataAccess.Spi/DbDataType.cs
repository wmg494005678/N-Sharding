using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据库数据类型
    /// </summary>
    public enum DbDataType
    {
        UnKnown = -2,
        Default = -1,
        Char = 0,
        VarChar = 1,
        Int = 2,
        Decimal = 3,
        Blob = 4,
        DateTime = 5,
        Cursor = 6,
        Clob = 7,
        NVarChar = 8,
        NClob = 9,
    }
}

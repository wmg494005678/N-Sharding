using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 查询投影字段类型枚举
    /// </summary>
    public enum QueryProjectionFieldType
    {
        Element = 0,
        Column = 1,
        FunctionExpression = 2
    }
}

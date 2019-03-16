using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    [Serializable]
    public enum DbType
    {
        SQLServer,
        MySQL,
        Other,
        Oracle
    }
}

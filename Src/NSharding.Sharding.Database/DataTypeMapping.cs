using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据库数据类型映射
    /// </summary>
    [Serializable]
    public class DataTypeMapping
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// 数据库数据类型
        /// </summary>
        public string DbDataType { get; set; }

        /// <summary>
        /// 默认长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 默认精度
        /// </summary>
        public int Precision { get; set; }
    }
}

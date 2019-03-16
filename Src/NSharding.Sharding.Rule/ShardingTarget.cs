using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// Sharding目标
    /// </summary>
    public class ShardingTarget
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
    }
}

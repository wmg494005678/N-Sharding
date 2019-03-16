using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// sharding类型
    /// </summary>
    public enum ShardingType
    {
        /// <summary>
        /// Hash分区
        /// </summary>
        Hash,

        /// <summary>
        /// 枚举分区
        /// </summary>
        Enum,

        /// <summary>
        /// 年度分区
        /// </summary>
        Year,

        /// <summary>
        /// 月度分区
        /// </summary>
        YearMonth,

        /// <summary>
        /// 年月日分区
        /// </summary>
        YearMonthMinute,

        /// <summary>
        /// 表达式
        /// </summary>
        Expression
    }
}

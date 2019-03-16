using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 分区列
    /// </summary>
    [Serializable]
    public class ShardingColumn : SystemBase
    {
        /// <summary>
        /// ID       
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 数据对象列ID
        /// </summary>
        public string DataColumnID { get; set; }

        /// <summary>
        /// 数据对象列名称
        /// </summary>
        public string DataColumnName { get; set; }

        /// <summary>
        /// 数据对象ID
        /// </summary>
        public string DataObjectID { get; set; }

        /// <summary>
        /// 数据对象名称
        /// </summary>
        public string DataObjectName { get; set; }

        /// <summary>
        /// 分区策略ID
        /// </summary>
        public string ShardingStrategyID { get; set; }
    }
}

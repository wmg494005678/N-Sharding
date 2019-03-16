using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 查询条件
    /// </summary>
    [Serializable]
    public class QueryCondition
    {
        /// <summary>
        /// 过滤条件
        /// </summary>
        public string FilterCondition { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string OrderByCondition { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public PageParameter PageParameter { get; set; }

        /// <summary>
        /// 限制数据返回行数
        /// </summary>
        public int LimitCount { get; set; }
    }
}

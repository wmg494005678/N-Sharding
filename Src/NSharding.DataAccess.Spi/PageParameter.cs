using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 分页参数
    /// </summary>
    [Serializable]
    public class PageParameter
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }
    }
}

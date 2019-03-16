using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 结果集映射项类
    /// </summary>
    public class ResultMappingItem
    {
        /// <summary>
        /// 属性
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 数据库列
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string NullValue { get; set; }

        /// <summary>
        /// 是否懒加载
        /// </summary>
        public bool LazyLoad { get; set; }

        /// <summary>
        /// 复杂类型的结果集映射
        /// </summary>
        public ResultMapping ResultMapping { get; set; }

        /// <summary>
        /// 分组列
        /// </summary>
        public string GroupbyColumn { get; set; }

        /// <summary>
        /// 类型处理器
        /// </summary>
        public string TypeHandler { get; set; }

        /// <summary>
        /// 结果集映射项类型
        /// </summary>
        public ResultMappingItemType ItemType { get; set; }
    }
}

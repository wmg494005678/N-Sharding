using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 结果集映射类
    /// </summary>
    /// <remarks>
    /// 基于领域对象和数据对象生成结果集映射，用于ORMapping.
    /// </remarks>
    public class ResultMapping
    {
        /// <summary>
        /// 关联的领域模型
        /// </summary>
        public string DomainObject { get; set; }

        /// <summary>
        /// 类的类型信息
        /// </summary>
        /// <remarks>
        /// fullyQualifiedClassName,assembly
        /// </remarks>
        public string ClassType { get; set; }

        //结果集映射项集合
        private List<ResultMappingItem> mappingItems;

        /// <summary>
        /// 结果集映射项集合
        /// </summary>
        public List<ResultMappingItem> MappingItems
        {
            get
            {
                if (mappingItems == null)
                    mappingItems = new List<ResultMappingItem>();

                return mappingItems;
            }
            set
            {
                mappingItems = value;
            }
        }
    }
}

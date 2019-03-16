using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据类型
    /// </summary>
    [Serializable]
    public class DataType
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        //数据类型映射
        private List<DataTypeMapping> dataTypeMappings;

        /// <summary>
        /// 数据类型映射
        /// </summary>
        public List<DataTypeMapping> DataTypeMappings
        {
            get
            {
                if (dataTypeMappings == null)
                    dataTypeMappings = new List<DataTypeMapping>();

                return dataTypeMappings;
            }
            set
            {
                dataTypeMappings = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据列
    /// </summary>
    [Serializable]
    public class DataColumn : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 数据类型ID
        /// </summary>
        public string DataTypeID { get; set; }

        private DataType dataType;
        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType
        {
            get
            {
                return dataType;
            }
            set
            {
                dataType = value;
                if (value != null)
                {
                    DataTypeID = value.ID;
                }
            }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 列的顺序号
        /// </summary>
        public int ColumnOrder { get; set; }

        /// <summary>
        /// 能否为空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 是否系统内置字段
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 是否主键列
        /// </summary>
        public bool IsPkColumn { get; set; }

        /// <summary>
        /// 数据对象ID
        /// </summary>
        public string DataObjectID { get; set; }

        /// <summary>
        /// 是否是分区列
        /// </summary>
        public bool IsShardingColumn { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataColumn()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 返回表示当前对象的字符串。
        /// </summary>
        /// <returns>表示当前对象的字符串</returns>
        public override string ToString()
        {
            return string.Format("ID:{0}, ColumnName:{1}, DisplayName:{2}", ID, ColumnName, DisplayName);
        }
    }
}

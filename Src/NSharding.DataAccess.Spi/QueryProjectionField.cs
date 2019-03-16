using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 查询投影字段
    /// </summary>
    public class QueryProjectionField
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 查询投影字段类型
        /// </summary>
        public QueryProjectionFieldType FieldType { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="fieldType">查询投影字段类型</param>
        public QueryProjectionField(string content, QueryProjectionFieldType fieldType)
        {
            this.Content = content;
            this.FieldType = fieldType;
        }
    }
}

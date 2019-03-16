using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据类型工具类
    /// </summary>
    public class DataTypeUtils
    {
        /// <summary>
        /// 是否文本类型
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <returns>true:是;false:否</returns>
        public static bool IsTextType(string dataTypeID)
        {
            switch (dataTypeID.ToLower())
            {
                case "int":
                case "decimal":
                case "numberic":
                    return false;
                default:
                    return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 关联类型枚举
    /// </summary>
    [Serializable]
    public enum AssociateType
    {
        /// <summary>
        /// 主从连接模式
        /// </summary>
        InnerJoin = 0,

        /// <summary>
        /// 左连接模式
        /// </summary>
        OuterLeftJoin = 1,
    }
}

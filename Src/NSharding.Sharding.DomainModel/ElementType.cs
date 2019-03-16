using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 领域对象元素类型
    /// </summary>
    public enum ElementType
    {
        /// <summary>
        /// 通用元素
        /// </summary>
        Normal,

        ///// <summary>
        ///// 关联类型的元素
        ///// </summary>
        //Association,

        /// <summary>
        /// 枚举类型的元素
        /// </summary>
        Enum,

        /// <summary>
        /// 关联过来的元素
        /// </summary>
        Reference,

        /// <summary>
        /// 虚拟元素
        /// </summary>
        Virtual
    }
}

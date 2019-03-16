using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 元素数据类型
    /// </summary>
    public enum ElementDataType
    {
        String = 0,
        Text = 1,
        Integer = 2,
        Decimal = 3,
        Boolean = 4,
        Date = 5,
        DateTime = 6,
        Binary = 7,
        List = 8,
    }
}

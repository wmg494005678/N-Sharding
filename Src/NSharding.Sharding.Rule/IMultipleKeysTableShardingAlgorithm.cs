using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 多键的分表算法接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMultipleKeysTableShardingAlgorithm<T> : IMultipleKeysShardingAlgorithm<T>
        where T : IComparable
    {
    }
}

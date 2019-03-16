using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 多键的分库算法接口
    /// </summary>
    public interface IMultipleKeysDatabaseShardingAlgorithm<T> : IMultipleKeysShardingAlgorithm<T>
        where T : IComparable
    {
    }
}

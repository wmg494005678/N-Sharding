using NSharding.Sharding.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager
{
    /// <summary>
    /// 分库分区策略工厂类
    /// </summary>
    class ShardingStrategyFactory
    {
        /// <summary>
        /// 获取单键分库计算器
        /// </summary>
        /// <param name="strategy">数据库Sharding策略</param>
        /// <returns>分库计算器</returns>
        public static ISingleKeyDatabaseShardingAlgorithm GetSingKeyShardingAlgorithm(DatabaseShardingStrategy strategy)
        {
            ISingleKeyDatabaseShardingAlgorithm algorithm = null;

            switch (strategy.ShardingType)
            {
                case ShardingType.Year:
                    algorithm = new DatabaseShardingYearAlgorithm();
                    break;
                case ShardingType.Enum:
                    algorithm = new DatabaseShardingEnumAlgorithm();
                    break;
                case ShardingType.Hash:
                    algorithm = new DatabaseShardingHashAlgorithm(strategy.ShardingFactor);
                    break;
                default:
                    break;
            }

            return algorithm;
        }


        /// <summary>
        /// 获取单键表分区计算器
        /// </summary>
        /// <param name="strategy">表Sharding策略</param>
        /// <returns>表分区分库计算器</returns>
        public static ISingleKeyTableShardingAlgorithm GetSingKeyShardingAlgorithm(TableShardingStrategy strategy)
        {
            ISingleKeyTableShardingAlgorithm algorithm = null;

            switch (strategy.ShardingType)
            {
                case ShardingType.Year:
                    algorithm = new TableShardingYearAlgorithm();
                    break;
                case ShardingType.Enum:
                    algorithm = new TableShardingEnumAlgorithm();
                    break;
                case ShardingType.Hash:
                    algorithm = new TableShardingHashAlgorithm(strategy.ShardingFactor);
                    break;
                default:
                    break;
            }

            return algorithm;
        }
    }
}

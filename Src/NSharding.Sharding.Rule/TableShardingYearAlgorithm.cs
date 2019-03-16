using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 年度表分区算法
    /// </summary>
    public class TableShardingYearAlgorithm : ISingleKeyTableShardingAlgorithm
    {
        public string DoEqualSharding(List<string> availableTargetNames, ShardingValue shardingValue)
        {
            if (shardingValue.ValueDataType == typeof(string))
                return availableTargetNames.FirstOrDefault(i => i.EndsWith(shardingValue.Value.ToString()));
            else if (shardingValue.ValueDataType == typeof(long))
                return availableTargetNames.FirstOrDefault(i => i.EndsWith(shardingValue.IntValue.ToString()));
            else
                return availableTargetNames.FirstOrDefault(i => i.EndsWith(shardingValue.DateTimeValue.Year.ToString()));
        }

        public List<string> DoInSharding(List<string> availableTargetNames, ShardingValue shardingValue)
        {
            var result = new List<string>();
            foreach (var tableName in availableTargetNames)
            {
                if (shardingValue.ValueDataType == typeof(string))
                {
                    foreach (var value in shardingValue.Values)
                    {
                        if (tableName.EndsWith(value.ToString()))
                        {
                            result.Add(tableName);
                        }
                    }
                }
                else if (shardingValue.ValueDataType == typeof(long))
                {
                    foreach (var value in shardingValue.IntValues)
                    {
                        if (tableName.EndsWith(value.ToString()))
                        {
                            result.Add(tableName);
                        }
                    }
                }
                else
                {
                    foreach (var value in shardingValue.DateTimeValues)
                    {
                        if (tableName.EndsWith(value.Year.ToString()))
                        {
                            result.Add(tableName);
                        }
                    }
                }
            }

            return result;
        }

        public List<string> DoBetweenSharding(List<string> availableTargetNames, ShardingValue shardingValue)
        {
            var result = new List<string>();
            foreach (var tableName in availableTargetNames)
            {
                if (shardingValue.ValueDataType == typeof(string))
                {
                    if (tableName.EndsWith(shardingValue.RangeValues.Start) || tableName.EndsWith(shardingValue.RangeValues.End))
                    {
                        result.Add(tableName);
                    }
                }
                else if (shardingValue.ValueDataType == typeof(long))
                {
                    for (long i = shardingValue.IntRangeValues.Start; i <= shardingValue.IntRangeValues.End; i++)
                    {
                        if (tableName.EndsWith(i.ToString()))
                        {
                            result.Add(tableName);
                        }
                    }
                }
                else
                {
                    for (long i = shardingValue.DateTimeRangeValues.Start.Year; i <= shardingValue.DateTimeRangeValues.End.Year; i++)
                    {
                        if (tableName.EndsWith(i.ToString()))
                        {
                            result.Add(tableName);
                        }
                    }
                }
            }

            return result;
        }
    }
}

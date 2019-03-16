using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 枚举表分区算法
    /// </summary>
    public class TableShardingEnumAlgorithm : ISingleKeyTableShardingAlgorithm
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
            foreach (var dbName in availableTargetNames)
            {
                if (shardingValue.ValueDataType == typeof(string))
                {
                    foreach (var value in shardingValue.Values)
                    {
                        if (dbName.EndsWith(value.ToString()))
                        {
                            result.Add(dbName);
                        }
                    }
                }
                else if (shardingValue.ValueDataType == typeof(long))
                {
                    foreach (var value in shardingValue.IntValues)
                    {
                        if (dbName.EndsWith(value.ToString()))
                        {
                            result.Add(dbName);
                        }
                    }
                }
                else
                {
                    foreach (var value in shardingValue.DateTimeValues)
                    {
                        if (dbName.EndsWith(value.Year.ToString()))
                        {
                            result.Add(dbName);
                        }
                    }
                }
            }

            return result;
        }

        public List<string> DoBetweenSharding(List<string> availableTargetNames, ShardingValue shardingValue)
        {
            var result = new List<string>();
            foreach (var dbName in availableTargetNames)
            {
                if (shardingValue.ValueDataType == typeof(string))
                {
                    if (dbName.EndsWith(shardingValue.RangeValues.Start) || dbName.EndsWith(shardingValue.RangeValues.End))
                    {
                        result.Add(dbName);
                    }
                }
                else if (shardingValue.ValueDataType == typeof(long))
                {
                    for (long i = shardingValue.IntRangeValues.Start; i <= shardingValue.IntRangeValues.End; i++)
                    {
                        if (dbName.EndsWith(i.ToString()))
                        {
                            result.Add(dbName);
                        }
                    }
                }
                else
                {
                    for (long i = shardingValue.DateTimeRangeValues.Start.Year; i <= shardingValue.DateTimeRangeValues.End.Year; i++)
                    {
                        if (dbName.EndsWith(i.ToString()))
                        {
                            result.Add(dbName);
                        }
                    }
                }
            }

            return result;
        }
    }
}

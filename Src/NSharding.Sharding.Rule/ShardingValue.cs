using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// Sharding的值
    /// </summary>    
    public class ShardingValue
    {
        /// <summary>
        /// 逻辑表名
        /// </summary>
        public string DomainObjectName { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string ShardingKey { get; set; }

        /// <summary>
        /// Sharding值类型
        /// </summary>
        public ShardingValueType ShardingValueType { get; private set; }

        //单个值
        private string value;

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        //列表值
        private List<string> values;

        public List<string> Values
        {
            get
            {
                if (values == null)
                    values = new List<string>();

                return values;
            }
            set
            {
                values = value;
            }
        }

        //范围值
        private Range<string> rangeValues;

        public Range<string> RangeValues
        {
            get
            {
                return rangeValues;
            }
            set
            {
                rangeValues = value;
            }
        }

        /// <summary>
        /// 整型值
        /// </summary>
        public long IntValue { get; set; }

        /// <summary>
        /// 值数据类型
        /// </summary>
        public Type ValueDataType { get; private set; }

        //列表值
        private List<long> intValues;

        /// <summary>
        /// 整型值列表
        /// </summary>
        public List<long> IntValues
        {
            get
            {
                if (intValues == null)
                    intValues = new List<long>();

                return intValues;
            }
            set
            {
                intValues = value;
            }
        }

        //整型范围值
        private Range<long> intRangeValues;

        public Range<long> IntRangeValues
        {
            get
            {
                return intRangeValues;
            }
            set
            {
                intRangeValues = value;
            }
        }

        /// <summary>
        /// 日期值
        /// </summary>
        public DateTime DateTimeValue { get; set; }

        //列表值
        private List<DateTime> dateTimeValues;

        /// <summary>
        /// 日期值列表
        /// </summary>
        public List<DateTime> DateTimeValues
        {
            get
            {
                if (dateTimeValues == null)
                    dateTimeValues = new List<DateTime>();

                return dateTimeValues;
            }
            set
            {
                dateTimeValues = value;
            }
        }

        //日期范围值
        private Range<DateTime> dateRangeValues;

        public Range<DateTime> DateTimeRangeValues
        {
            get
            {
                return dateRangeValues;
            }
            set
            {
                dateRangeValues = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, string value)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.value = value;
            this.ShardingValueType = Rule.ShardingValueType.SINGLE;
            this.ValueDataType = typeof(string);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, List<string> values)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.values = values;
            this.ShardingValueType = Rule.ShardingValueType.LIST;
            this.ValueDataType = typeof(string);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, Range<string> rangeValues)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.rangeValues = rangeValues;
            this.ShardingValueType = Rule.ShardingValueType.RANGE;
            this.ValueDataType = typeof(string);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, long value)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.IntValue = value;
            this.ShardingValueType = Rule.ShardingValueType.SINGLE;
            this.ValueDataType = typeof(long);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, List<long> values)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.intValues = values;
            this.ShardingValueType = Rule.ShardingValueType.LIST;
            this.ValueDataType = typeof(long);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, Range<long> rangeValues)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.intRangeValues = rangeValues;
            this.ShardingValueType = Rule.ShardingValueType.RANGE;
            this.ValueDataType = typeof(long);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, DateTime value)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.DateTimeValue = value;
            this.ShardingValueType = Rule.ShardingValueType.SINGLE;
            this.ValueDataType = typeof(DateTime);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, List<DateTime> values)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.dateTimeValues = values;
            this.ShardingValueType = Rule.ShardingValueType.LIST;
            this.ValueDataType = typeof(DateTime);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domainObjectName">领域对象名称</param>
        /// <param name="shardingKey">键</param>
        /// <param name="value">值</param>
        public ShardingValue(string domainObjectName, string shardingKey, Range<DateTime> rangeValues)
        {
            this.DomainObjectName = domainObjectName;
            this.ShardingKey = shardingKey;
            this.dateRangeValues = rangeValues;
            this.ShardingValueType = Rule.ShardingValueType.RANGE;
            this.ValueDataType = typeof(DateTime);
        }
    }

    /// <summary>
    /// Sharding值类型
    /// </summary>
    public enum ShardingValueType
    {
        SINGLE, LIST, RANGE
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSharding.DomainModel.Spi;
using NSharding.Sharding.Rule;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据保存服务接口
    /// </summary>
    public interface IDataSaveService
    {
        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="instance">对象实例</param>
        /// <param name="shardingValue">分区分表键值对</param>
        void Save(DomainModel.Spi.DomainModel domainModel, object instance, ShardingValue shardingValue = null);

        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="instanceList">对象实例集合</param>
        /// <param name="shardingValueList">分区分表键值对集合</param>
        void SaveBatch(DomainModel.Spi.DomainModel domainModel, List<object> instanceList, List<ShardingValue> shardingValueList = null);

        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="domainObject">领域对象</param>
        /// <param name="instance">对象实例</param>
        /// <param name="shardingValue">分区分表键值对</param>
        void Save(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, object instance, ShardingValue shardingValue = null);

        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="domainObject">领域对象</param>
        /// <param name="instance">对象实例</param>
        /// <param name="shardingValueList">分区分表键值对集合</param>
        void SaveBatch(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, IList<object> instanceList, List<ShardingValue> shardingValueList = null);
    }
}

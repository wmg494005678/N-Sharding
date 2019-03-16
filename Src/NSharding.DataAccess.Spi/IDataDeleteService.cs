using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSharding.Sharding.Rule;
using NSharding.DomainModel.Spi;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据删除接口
    /// </summary>
    public interface IDataDeleteService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <remarks>按主键数据作为查询依据</remarks>
        /// <param name="domainModel">领域模型</param>        
        /// <param name="dataID">主键数据</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>删除SQL</returns>
        void DeleteByID(DomainModel.Spi.DomainModel domainModel, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <remarks>按主键数据作为查询依据</remarks>
        /// <param name="domainModel">领域模型</param>        
        /// <param name="dataID">主键数据</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>删除SQL</returns>
        void DeleteByIDs(DomainModel.Spi.DomainModel domainModel, IEnumerable<string> dataIDs, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 删除
        /// </summary>
        /// <remarks>按主键数据作为查询依据</remarks>
        /// <param name="domainModel">领域模型</param> 
        /// <param name="domainObject">领域对象</param>
        /// <param name="dataID">主键数据</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>删除SQL</returns>
        void DeleteByID(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <remarks>按主键数据作为查询依据</remarks>
        /// <param name="domainModel">领域模型</param> 
        /// <param name="domainObject">领域对象</param>
        /// <param name="dataID">主键数据</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>删除SQL</returns>
        void DeleteByIDs(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, IEnumerable<string> dataIDs, ShardingValue shardingKeyValue = null);
    }
}

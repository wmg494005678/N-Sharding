using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSharding.Sharding.Rule;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据访问接口
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// 原生数据访问接口
        /// </summary>
        IDatabase Database { get; }

        #region Save

        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="instance">对象实例</param>
        void Save(string domainModelID, object instance);

        /// <summary>
        /// 保存指定对象的数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="instances">对象实例</param>
        void Save(string domainModelID, string domainObjectID, params object[] instances);

        #endregion

        #region Delete

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, string dataId, ShardingValue shardingKeyValue = null);

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataIds">数据唯一标识集合</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, IList<string> dataIds, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, IDictionary<string, object> dataId, ShardingValue shardingKeyValue = null);

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, string domainObjectID, string dataId, ShardingValue shardingKeyValue = null);

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="dataIds">数据唯一标识集合</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, string domainObjectID, IList<string> dataIds, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void Delete(string domainModelID, string domainObjectID, IDictionary<string, object> dataId, ShardingValue shardingKeyValue = null);

        #endregion

        #region Update

        /// <summary>
        /// 全量更新
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="instance">对象实例</param>
        void Update(string domainModelID, object instance, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 全量更新指定对象的数据
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="instance">对象实例</param>
        void Update(string domainModelID, string domainObjectID, object instance, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 增量更新
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="changeSet">变更集</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void UpdateChangeset(string domainModelID, IDictionary<string, object> changeSet, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 增量更新
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="changeSet">变更集</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void UpdateChangeset(string domainModelID, string domainObjectID, IDictionary<string, object> changeSet, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 增量更新
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="changeSet">变更集</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void UpdateChangeset(string domainModelID, IDictionary<string, object> changeSet, IDictionary<string, object> dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 增量更新
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="changeSet">变更集</param>
        /// <param name="dataId">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        void UpdateChangeset(string domainModelID, string domainObjectID, IDictionary<string, object> changeSet, IDictionary<string, object> dataID, ShardingValue shardingKeyValue = null);

        #endregion

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        T GetObject<T>(string domainModelID, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        T GetObject<T>(string domainModelID, IDictionary<string, object> dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>true:存在; false:不存在</returns>
        bool IsExist(string domainModelID, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>true:存在; false:不存在</returns>
        bool IsExist(string domainModelID, IDictionary<string, object> dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="filter">查询过滤器</param>
        /// <returns>对象数据</returns>
        IEnumerable<T> GetObject<T>(string domainModelID, QueryFilter filter);

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="filter">查询过滤器</param>
        /// <returns>对象数据</returns>
        IEnumerable<T> GetObject<T>(string domainModelID, string domainObjectID, QueryFilter filter);

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        T GetObject<T>(string domainModelID, string domainObjectID, string dataID, ShardingValue shardingKeyValue = null);

        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="domainModelID">领域模型ID</param>
        /// <param name="domainObjectID">领域对象ID</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingKeyValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        T GetObject<T>(string domainModelID, string domainObjectID, IDictionary<string, object> dataID, ShardingValue shardingKeyValue = null);

        #region  Transaction

        /// <summary>
        /// 启动事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();

        /// <summary>
        /// 事务回滚
        /// </summary>
        void Rollback();

        #endregion
    }
}

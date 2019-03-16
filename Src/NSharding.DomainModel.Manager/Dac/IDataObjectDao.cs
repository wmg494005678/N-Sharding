using NSharding.Sharding.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 数据对象持久化访问接口
    /// </summary>
    public interface IDataObjectDao
    {
        /// <summary>
        /// 数据对象保存
        /// </summary>
        /// <param name="dataObject">数据对象</param>
        void SaveDataObject(DataObject dataObject);

        /// <summary>
        /// 删除数据对象
        /// </summary>
        /// <param name="id">数据对象ID</param>
        void DeleteDataObject(string id);

        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="id">数据对象ID</param>
        /// <returns>数据对象</returns>
        DataObject GetDataObject(string id);
    }
}

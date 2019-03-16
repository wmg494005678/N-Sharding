using NSharding.Sharding.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 数据对象管理类
    /// </summary>
    public class DataObjectManager
    {
        /// <summary>
        /// 数据对象保存
        /// </summary>
        /// <param name="dataObject">数据对象</param>
        public void SaveDataObject(DataObject dataObject)
        {
            if (dataObject == null)
                throw new ArgumentNullException("DataObjectManager.SaveDataObject.dataObject");

            DacServiceManager.GetDataObjectDao().SaveDataObject(dataObject);
        }

        /// <summary>
        /// 删除数据对象
        /// </summary>
        /// <param name="id">数据对象ID</param>
        public void DeleteDataObject(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("DataObjectManager.DeleteDataObject.id");

            DacServiceManager.GetDataObjectDao().DeleteDataObject(id);
        }

        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="id">数据对象ID</param>
        /// <returns>数据对象</returns>
        public DataObject GetDataObject(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("DataObjectManager.GetDataObject.id");

            return DacServiceManager.GetDataObjectDao().GetDataObject(id);
        }
    }
}

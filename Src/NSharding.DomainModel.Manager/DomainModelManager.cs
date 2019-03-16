using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 领域模型管理类
    /// </summary>
    public class DomainModelManager
    {
        /// <summary>
        /// 数据领域对象
        /// </summary>
        /// <param name="dataObject">领域对象</param>
        public void SaveDomainModel(DomainModel.Spi.DomainModel domainModel)
        {
            if (domainModel == null)
                throw new ArgumentNullException("DomainModelManager.SaveDomainModel.domainModel");

            var asso = domainModel.DomainObjects.SelectMany(i => i.Associations).ToList();
            var assoItems = asso.SelectMany(i => i.Items).ToList();

            using (var tran = new TransactionScope(TransactionScopeOption.Required))
            {
                DacServiceManager.GetDomainModelDao().SaveDomainModel(domainModel);
                foreach (var domainObject in domainModel.DomainObjects)
                {
                    DacServiceManager.GetDomainModelDao().SaveDomainObjectElements(domainObject.Elements);
                }
                if (asso.Count > 0)
                    DacServiceManager.GetDomainModelDao().SaveDomainAssociation(asso);
                if (assoItems.Count > 0)
                    DacServiceManager.GetDomainModelDao().SaveDomainAssociationItem(assoItems);

                tran.Complete();
            }
        }

        /// <summary>
        /// 删除领域对象
        /// </summary>
        /// <param name="id">领域对象ID</param>
        public void DeleteDomainModel(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("DomainModelManager.DeleteDomainModel.id");

            DacServiceManager.GetDomainModelDao().DeleteDomainModel(id);
        }

        /// <summary>
        /// 获取领域对象
        /// </summary>
        /// <param name="id">领域对象ID</param>
        /// <returns>领域对象</returns>
        public DomainModel.Spi.DomainModel GetDomainModel(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("DomainModelManager.GetDomainModel.id");

            var domainModel = DacServiceManager.GetDomainModelDao().GetDomainModel(id);
            if (domainModel.RootDomainObject == null && !string.IsNullOrWhiteSpace(domainModel.RootDomainObjectID))
            {
                var modelObject = domainModel.DomainObjects.FirstOrDefault(i => i.ID == domainModel.RootDomainObjectID);

                domainModel.RootDomainObject = modelObject;
            }

            //构造领域模型树形结构
            foreach (var modelObject in domainModel.DomainObjects)
            {
                var childObjects = domainModel.DomainObjects.Where(i => i.ParentObjectID == modelObject.ID);
                if (childObjects != null)
                {
                    foreach (var tempObject in childObjects)
                    {
                        tempObject.ParentObject = modelObject;
                        modelObject.ChildDomainObjects.Add(tempObject);
                    }
                }
            }

            return domainModel;
        }
    }
}

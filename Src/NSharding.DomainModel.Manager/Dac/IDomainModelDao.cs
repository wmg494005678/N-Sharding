using NSharding.DomainModel.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 领域模型持久化接口
    /// </summary>
    public interface IDomainModelDao
    {
        /// <summary>
        /// 数据领域对象
        /// </summary>
        /// <param name="dataObject">领域对象</param>
        void SaveDomainModel(DomainModel.Spi.DomainModel domainModel);

        /// <summary>
        /// 保存领域对象元素集合
        /// </summary>
        /// <param name="elements">领域对象元素集合</param>
        void SaveDomainObjectElements(List<DomainObjectElement> elements);

        /// <summary>
        /// 保存领域对象关联集合
        /// </summary>
        /// <param name="associations">领域对象关联集合</param>
        void SaveDomainAssociation(List<Association> associations);

        /// <summary>
        /// 保存领域对象关联项集合
        /// </summary>
        /// <param name="associations">领域对象关联项集合</param>
        void SaveDomainAssociationItem(List<AssociateItem> associateItems);

        /// <summary>
        /// 删除领域对象
        /// </summary>
        /// <param name="id">领域对象ID</param>
        void DeleteDomainModel(string id);

        /// <summary>
        /// 获取领域对象
        /// </summary>
        /// <param name="id">领域对象ID</param>
        /// <returns>领域对象</returns>
        DomainModel.Spi.DomainModel GetDomainModel(string id);
    }
}

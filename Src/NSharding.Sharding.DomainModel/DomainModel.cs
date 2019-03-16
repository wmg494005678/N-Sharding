using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 领域模型
    /// </summary>
    [Serializable]
    public class DomainModel : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        private DomainObject rootDomainObject;

        /// <summary>
        /// 根节点领域对象
        /// </summary>
        public DomainObject RootDomainObject
        {
            get
            {
                return rootDomainObject;
            }
            set
            {
                rootDomainObject = value;
                if (value != null)
                {
                    RootDomainObjectID = value.ID;
                }
            }
        }

        /// <summary>
        /// 根节点领域对象ID
        /// </summary>
        public string RootDomainObjectID { get; set; }

        //领域对象集合
        [NonSerialized]
        private List<DomainObject> domainObjects;

        /// <summary>
        /// 领域对象集合
        /// </summary>        
        public List<DomainObject> DomainObjects
        {
            get
            {
                if (domainObjects == null)
                    domainObjects = new List<DomainObject>();

                return domainObjects;
            }
            set
            {
                domainObjects = value;
            }
        }

        /// <summary>
        /// 是否缓存
        /// </summary>
        public bool IsCache { get; set; }

        /// <summary>
        /// 缓存策略
        /// </summary>
        public string CacheStrategy { get; set; }

        /// <summary>
        /// 是否逻辑删除,True:是，false:否
        /// </summary>
        public bool IsLogicDelete { get; set; }

        /// <summary>
        /// 数据加载配置
        /// </summary>
        public string DataLoaderConfig { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 重排领域对象
        /// </summary>
        /// <remarks>
        /// 明细级在顶端
        /// </remarks>
        public List<DomainObject> ReverseDomainObjects
        {
            get
            {
                var modelObjects = new List<DomainObject>();
                modelObjects.Add(this.RootDomainObject);
                foreach (var childObject in this.RootDomainObject.ChildDomainObjects)
                {
                    modelObjects.Add(childObject);
                    if (childObject.ChildDomainObjects.Count > 0)
                    {
                        Reverse(childObject, modelObjects);
                    }
                }

                modelObjects.Reverse();

                return modelObjects;
            }
        }

        private void Reverse(DomainObject modelObject, List<DomainObject> modelObjects)
        {
            if (modelObject.ChildDomainObjects.Count > 0)
            {
                foreach (var childObject in modelObject.ChildDomainObjects)
                {
                    modelObjects.Add(childObject);
                }
            }
        }

        /// <summary>
        /// 重载ToString方法
        /// </summary>
        /// <remarks>
        /// 方便调试
        /// </remarks>
        /// <returns>CO通用中间对象概述</returns>
        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, RootNode: {2}, Nodes: {3}", ID, Name, this.RootDomainObject.Name, DomainObjects.Count);
        }
    }
}

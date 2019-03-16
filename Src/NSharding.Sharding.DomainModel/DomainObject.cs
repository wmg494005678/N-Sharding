using NSharding.Sharding.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 领域对象
    /// </summary>
    [Serializable]
    public class DomainObject : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否为根结点对象
        /// </summary>
        public bool IsRootObject { get; set; }

        [NonSerialized]
        private DomainModel domainModel;

        /// <summary>
        /// 隶属的领域模型
        /// </summary>        
        public DomainModel DomainModel
        {
            get
            {
                return domainModel;
            }
            set
            {
                domainModel = value;
                if (value != null)
                    DomainModelID = value.ID;
            }
        }

        /// <summary>
        /// 隶属的领域模型ID
        /// </summary>
        public string DomainModelID { get; set; }

        [NonSerialized]
        private DomainObject parentObject;

        /// <summary>
        /// 父级领域对象
        /// </summary>
        public DomainObject ParentObject
        {
            get
            {
                return parentObject;
            }
            set
            {
                parentObject = value;
                if (value != null)
                    ParentObjectID = value.ID;
            }
        }

        /// <summary>
        /// 父级领域对象ID
        /// </summary>
        public string ParentObjectID { get; set; }

        //子领域对象集合
        private List<DomainObject> childDomainObjects;

        /// <summary>
        /// 子领域对象集合
        /// </summary>
        public List<DomainObject> ChildDomainObjects
        {
            get
            {
                if (childDomainObjects == null)
                    childDomainObjects = new List<DomainObject>();

                return childDomainObjects;
            }
            set
            {
                childDomainObjects = value;
            }
        }

        //元素集合
        private List<DomainObjectElement> elements;

        /// <summary>
        /// 元素集合
        /// </summary>
        public List<DomainObjectElement> Elements
        {
            get
            {
                if (elements == null)
                    elements = new List<DomainObjectElement>();

                return elements;
            }
            set
            {
                elements = value;
            }
        }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        ///// <summary>
        ///// 类名称
        ///// </summary>
        //public string Clazz { get; set; }

        /// <summary>
        /// 类反射信息
        /// </summary>
        public string ClazzReflectType { get; set; }

        [NonSerialized]
        private DataObject dataObject;

        /// <summary>
        /// 关联的数据对象
        /// </summary>
        public DataObject DataObject
        {
            get
            {
                return dataObject;
            }
            set
            {
                dataObject = value;
            }
        }

        /// <summary>
        /// 数据对象ID
        /// </summary>
        public string DataObjectID { get; set; }

        /// <summary>
        /// 是否懒加载
        /// </summary>
        public bool IsLazyLoad { get; set; }

        private List<Association> associations;

        /// <summary>
        /// 关联
        /// </summary>
        public List<Association> Associations
        {
            get
            {
                if (associations == null)
                    associations = new List<Association>();

                return associations;
            }
            set
            {
                associations = value;
            }
        }
    }
}

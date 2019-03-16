using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 关联
    /// </summary>
    [Serializable]
    public class Association : SystemBase
    {
        /// <summary>
        /// 标识
        /// </summary>        
        public string ID { get; set; }

        /// <summary>
        /// 关联的名称
        /// </summary>
        /// <remarks>
        /// 主要用于显示和按关联取数
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// 领域模型ID
        /// </summary>
        public string DomainModelID { get; set; }

        /// <summary>
        /// 领域对象ID
        /// </summary>
        public string DomainObjectID { get; set; }

        /// <summary>
        /// 关联的领域模型ID
        /// </summary>
        public string AssoDomainModelID { get; set; }

        private DomainModel assoDomaiModel;
        /// <summary>
        /// 关联的领域模型ID
        /// </summary>
        public DomainModel AssoDomaiModel
        {
            get
            {
                return assoDomaiModel;
            }
            set
            {
                assoDomaiModel = value;
                if (value != null)
                {
                    AssoDomainModelID = value.ID;
                }
            }
        }

        /// <summary>
        /// 关联的领域对象ID
        /// </summary>
        public string AssoDomainObjectID { get; set; }

        [NonSerialized]
        private DomainObject assoDomainObject;

        /// <summary>
        /// 关联的领域对象
        /// </summary>
        public DomainObject AssoDomainObject
        {
            get
            {
                return assoDomainObject;
            }
            set
            {
                assoDomainObject = value;

                if (value != null)
                    AssoDomainObjectID = value.ID;
            }
        }

        /// <summary>
        /// 关联类型
        /// </summary>
        public AssociateType AssociateType { get; set; }

        /// <summary>
        /// 关联上的设置的过滤条件
        /// </summary>        
        public string FilterCondition { get; set; }

        //关联项
        private List<AssociateItem> items;

        /// <summary>
        /// 关联项
        /// </summary>
        public List<AssociateItem> Items
        {
            get
            {
                if (items == null)
                    items = new List<AssociateItem>();

                return items;
            }
            set
            {
                items = value;
            }
        }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public string PropertyType { get; set; }

        /// <summary>
        /// 是否懒加载
        /// </summary>
        public bool IsLazyLoad { get; set; }

        //关联带出的元素
        private List<AssociationRefElement> refElements;

        /// <summary>
        /// 关联带出的元素
        /// </summary>
        public List<AssociationRefElement> RefElements
        {
            get
            {
                if (refElements == null)
                {
                    refElements = new List<AssociationRefElement>();
                }

                return refElements;
            }
            set
            {
                refElements = value;
            }
        }
    }
}

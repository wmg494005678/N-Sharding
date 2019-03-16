using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 领域对象元素
    /// </summary>
    [Serializable]
    public class DomainObjectElement : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        private string displayName;
        /// <summary>
        /// 描述
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(displayName))
                    displayName = Name;

                return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        /// <summary>
        /// 标签
        /// </summary>
        private string alias;

        /// <summary>
        /// 标签
        /// </summary>        
        public virtual string Alias
        {
            get
            {
                if (string.IsNullOrWhiteSpace(alias))
                    return Name;

                return alias;
            }
            set
            {
                alias = value;
            }
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public virtual ElementDataType DataType { get; set; }

        /// <summary>
        /// 长度
        /// </summary>       
        public virtual int Length { get; set; }

        /// <summary>
        /// 精度
        /// </summary>        
        public virtual int Precision { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>        
        public virtual string DefaultValue { get; set; }

        /// <summary>
        /// 隶属的领域对象ID
        /// </summary>
        public virtual string DomainObjectID { get; set; }

        /// <summary>
        /// 元素类型
        /// </summary>
        public virtual ElementType ElementType { get; set; }

        /// <summary>
        /// 对应的数据列ID
        /// </summary>
        public virtual string DataColumnID { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public virtual string PropertyName { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public virtual string PropertyType { get; set; }

        /// <summary>
        /// 查询时是否必须
        /// </summary>
        public virtual bool IsForQuery { get; set; }

        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool IsAllowNull { get; set; }

        /// <summary>
        /// 返回表示当前对象的字符串。
        /// </summary>
        /// <returns>表示当前对象的字符串</returns>
        public override string ToString()
        {
            return string.Format("ID:{0}, Name:{1}, DataType:{2}, DataColumnID:{3}, PropertyName:{4}", ID, Name, DataType, DataColumnID, PropertyName);
        }
    }
}

using System.Reflection;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopeeKorean.Entities.Models
{
    public abstract class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        [IgnoreDataMember]
        public static readonly PropertyInfo[] PropertyInfos;

        //Static constructor chỉ chạy một lần cho mỗi generic type T
        static BaseEntity()
        {
            PropertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }
    }
}

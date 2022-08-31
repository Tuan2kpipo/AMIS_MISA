using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Interface.MISAAttribute
{
    // Muốn đánh dấu cho property
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty:Attribute
    {

    }

   
        // Muốn đánh dấu cho property
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }


    //Gán tên
    [AttributeUsage(AttributeTargets.Property)]
    public class ProppertyName : Attribute
    {
        public string Name = String.Empty;

        public ProppertyName(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotMapInSertQuery : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInData : Attribute
    {

    }


    /// <summary>
    /// Attribute không map giá trị trong thêm vào dynamic parameters
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAOverMapping : Attribute
    {

    }

}

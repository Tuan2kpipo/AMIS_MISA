using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web06.Core.Entities;
namespace MISA.Web06.Core.Interface.Services
{
    public interface IEmployeeServices:IBaseService<Employee>
    {
     



        /// <summary>
        /// Lấy mã nhân viên mới nhất chưa có trong database
        /// </summary>
        string GetNewEmployeeCode();


 
    }
}

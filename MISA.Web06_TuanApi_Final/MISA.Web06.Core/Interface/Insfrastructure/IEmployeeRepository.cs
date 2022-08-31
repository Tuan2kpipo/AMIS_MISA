using MISA.Web06.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Interface.Insfrastructure
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {




        /// <summary>
        /// Check trung ma
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        bool CheckDuplicateCode(string employeeCode);


        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất trong csdl</returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        string GetMaxEmloyeeCode();


        /// <summary>
        /// Lấy danh sách để export
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        IEnumerable<EmployeeExcel> Export();



        /// <summary>
        /// Phaan trang
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
 
        object GetPaging(int pageIndex, int pageSize, string? filter = "");

    }
}

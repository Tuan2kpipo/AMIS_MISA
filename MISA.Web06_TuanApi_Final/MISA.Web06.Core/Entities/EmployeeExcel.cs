using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Entities
{
    public class EmployeeExcel
    {
        #region Properties
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string? EmployeeName { get; set; }


        /// <summary>
        /// Giới tính
        /// </summary>
        public string? Gender { get; set; }


        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }


        /// <summary>
        /// Số cccd
        /// </summary>

        public string? IndentityNumber { get; set; }

        /// <summary>
        /// Tên chức danh
        /// </summary>
        /// 
        public string? PositionName { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// 
        public string? Email { get; set; }



        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 

        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// 

        public string? BankBranch { get; set; }

       

        #endregion
    }
}

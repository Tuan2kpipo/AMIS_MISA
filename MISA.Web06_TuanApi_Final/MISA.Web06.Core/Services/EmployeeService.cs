using MISA.Web06.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web06.Core.Entities;
using MISA.Web06.Core.Exceptions;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.SME.Core.Helpers;
using System.Text.RegularExpressions;

namespace MISA.Web06.Core.Services
{
    public class EmployeeService:BaseService<Employee>, IEmployeeServices
    {
        #region Fields
        IEmployeeRepository _employeeRepository;
        #endregion


        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion



        #region Methods
        /// <summary>
        /// Lấy mã nhân viên mới nhất chưa có trong database
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public string GetNewEmployeeCode()
        {
            string maxEmpCode = _employeeRepository.GetMaxEmloyeeCode();
            if (string.IsNullOrEmpty(maxEmpCode))
            {
                return "";
            }
            // lấy chuỗi số hợp lệ cuối cùng trong chuỗi
            string? lastValidNumber = StringUtils.findLastValidNum(maxEmpCode);
            if (lastValidNumber == null)
            {
                return "";
            }
            return StringUtils.ReplaceLastOccurrence(maxEmpCode, lastValidNumber, (int.Parse(lastValidNumber) + 1).ToString());

        }


 

        /// <summary>
        /// Validate nhân viên (các trường bắt buộc)
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: ND_Tuan(17/08/2022)
        protected override void ValidateEmployee(Employee employee)
        {
            //check trung ma
            var isDuplicate = _employeeRepository.CheckDuplicateCode(employee.EmployeeCode);
            bool valid = true;
            if (isDuplicate == true)
            {
                throw new MISAValidateException(Core.Resources.ResourceVN.EmployeeCode_Duplicate);
            }
            //Tên nhân viên không được để trống
            if (employee.EmployeeName == null || employee.EmployeeName.Length == 0)
            {
                valid = false;
                throw new MISAValidateException(Core.Resources.ResourceVN.EmployeeName_NotEmpty);
            }
            //check ngày sinh sao cho ngày sih không được > ngày hiện tại
            if (employee.DateOfBirth > DateTime.Now)
            {
                throw new MISAValidateException(Core.Resources.ResourceVN.DateOfBirth);
            }
            //Kiểm tra email có đúng định dạng không-nếu email khác null
            var reg = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            if (employee.Email != null && !reg.IsMatch(employee.Email))
            {
                valid = false;
                throw new MISAValidateException(Core.Resources.ResourceVN.Email_Format);
            };
        }



        /// <summary>
        /// Thực hiện sửa thông tin nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int UpdateService(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
        #endregion
    }
}

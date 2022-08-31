using MISA.Web06.Core.Interface.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web06.Core.Enum;
namespace MISA.Web06.Core.Entities
{
    public class Employee: BaseEntities
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        /// 
        [PrimaryKey]
        [PropertyInData]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>

        [NotEmpty]
        [ProppertyName("Họ và tên")]
        [PropertyInData]
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [NotEmpty]
        [ProppertyName("Mã nhân viên")]
        [PropertyInData]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [PropertyInData]
        public DateTime? DateOfBirth { get; set; }

        [PropertyInData]
        public Guid DepartmentId { get; set; }

        [PropertyInData]
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [PropertyInData]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Số cccd
        /// </summary>
        [PropertyInData]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày tạo cccd
        /// </summary>
        /// 
        [PropertyInData]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// 
        [PropertyInData]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// 
        [PropertyInData]
        public string? Email { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// 
        [PropertyInData]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// 
        [PropertyInData]
        public string? PhoneLandline { get; set; }




    

        /// <summary>
        /// Quê quán
        /// </summary>
        /// 
        [PropertyInData]
        public string? Address { get; set; }

        /// <summary>
        /// Tên chức danh
        /// </summary>
        [PropertyInData]
        public string? PositionName { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// 
        [PropertyInData]
        public string? BankNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 
        [PropertyInData]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// 
        [PropertyInData]
        public string? BankBranch { get; set; }





        [NotMapInSertQuery]
        public string? GenderName { 
            get
            {
                switch (Gender)
                {
                    case Enum.Gender.Other:
                        return Core.Resources.ResourceVN.Gender_Other;
                    case Enum.Gender.Female:
                        return Core.Resources.ResourceVN.Gender_Female;
                    case Enum.Gender.Male: 
                        return Core.Resources.ResourceVN.Gender_Male;
                    default:
                        return null;
                        break;

                }

            }
        }
    }
}

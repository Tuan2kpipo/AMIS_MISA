using MISA.Web06.Core.Entities;
using MISA.Web06.Core.Interface.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;

namespace MISA.Web06.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository

    {
        #region Methods

        /// <summary>
        /// Kiểm tra mã trùng
        /// <returns>
        /// recordStart (trang bắt đầu), recordEnd (trang cuối), totalRecord (tổng trang)
        /// Data (các bản ghi)
        /// CreatedBy: ND_Tuan(15/08/2022)
        public bool CheckDuplicateCode(string employeeCode)
        {
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                //tao ket noi
                var sqlConnection = new MySqlConnection(connectionString);
                // Ma nhan vien khong duoc trung
                var sqlCheck = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";
                var employeeCodeDuplicate = sqlConnection.QueryFirstOrDefault<string>(sqlCheck, param: new { EmployeeCode = employeeCode });
                if (employeeCodeDuplicate != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
 
        public string GetMaxEmloyeeCode()
        {
            var sql = @"select max(EmployeeCode) from Employee";
            var result = sqlConnection.QueryFirstOrDefault<string>(sql);
            return result;

        }

   

        /// <summary>
        /// lấy danh sách để export
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public IEnumerable<EmployeeExcel> Export()
        {
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                ///khởi tạo kết nối
               
                using (sqlConnection = new MySqlConnection(connectionString))
                {
                    //câu lệnh truy vấn
                    var sql = $"Proc_GetEmployeeExCel";


                    //thực hiện truy vấn
                    var employees = sqlConnection.Query<EmployeeExcel>(sql, commandType: System.Data.CommandType.StoredProcedure);

                    //trả về dữ liệu
                    return employees;
                }
            }
        }




        /// <summary>
        /// phân trang
        /// </summary>
        /// <param name="pageIndex">trang bắt đầu</param>
        /// <param name="pageSize">số lượng bản ghi trên 1 trang</param>
        /// <param name="filter">key tìm kiếm</param>
        /// <returns>
        /// recordStart (trang bắt đầu), recordEnd (trang cuối), totalRecord (tổng trang)
        /// Data (các bản ghi)
        /// </returns>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public object GetPaging(int pageIndex, int pageSize, string? filter = "")
        {
            using (sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = $"Proc_GetEmployeePaging";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@t_Filter", filter);
                parameters.Add("@t_PageIndex", pageIndex);
                parameters.Add("@t_PageSize", pageSize);
                parameters.Add("@t_TotalRecord", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@t_RecordStart", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@t_RecordEnd", direction: System.Data.ParameterDirection.Output);
                var employees = sqlConnection.Query<Employee>(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                int totalRecord = parameters.Get<int>("t_TotalRecord");
                int recordStart = parameters.Get<int>("t_RecordStart");
                int recordEnd = parameters.Get<int>("t_RecordEnd");
                return new
                {
                    TotalRecord = totalRecord,
                    RecordStart = recordStart,
                    RecordEnd = recordEnd,
                    Data = employees
                };
            }
        }

        #endregion

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web06.Core.Entities;
using MISA.Web06.Core.Exceptions;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.Services;
using MISA.Web06.Core.Services;
using MISA.Web06.Infrastructure.Repository;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Drawing;

namespace MISA.Web06.ApiFnial.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        #region Fields
        // làm việc qua Repository và Service
        IEmployeeRepository _employeeRepository;
        IEmployeeServices _emplyeeService;
        #endregion


        #region Contructor
        public EmployeesController(IEmployeeRepository employeeRepository, IEmployeeServices employeeService) : base(employeeService, employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _emplyeeService = employeeService;

        }
        #endregion


        #region Methods

        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>
        /// </returns>
        /// CreatedBy:ND_Tuan(15/08/2022)
        [HttpGet("newEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                // thực hiện gọi service
                string newEmployeeCode = _emplyeeService.GetNewEmployeeCode();
                return Ok(newEmployeeCode);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }

     


        /// <summary>
        /// Export Excel
        /// </summary>
        /// <returns>
        /// </returns>
        /// CreatedBy:ND_Tuan(20/08/2022)
        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            // query data from database  
            await Task.Yield();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            var employeeExcel = _employeeRepository.Export();
            var stream = new MemoryStream();

            //tạo thêm 3 hàng (vì tiêu đề chiếm 2 ô)
            var length = employeeExcel.Count() + 3;
            var cellLastBorder = "K" + length.ToString();
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Danh sách nhân viên");
                for (int i = 1; i <= length; i++)
                {
                    workSheet.Cells[$"A{i + 1}"].Value = i;
                    if (i == employeeExcel.Count())
                    {
                        break;
                    }
                }
                workSheet.Cells[$"B1:{cellLastBorder}"].LoadFromCollection(employeeExcel, true);
                workSheet.InsertRow(1, 2);
                workSheet.Cells["A1:K1"].Merge = true;
                //Make all text fit the cells
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                workSheet.Cells["A1"].Value = "DANH SÁCH NHÂN VIÊN";
                workSheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A3"].Value = "STT";
                workSheet.Cells["B3"].Value = "Mã nhân viên";
                workSheet.Cells["C3"].Value = "Tên nhân viên";
                workSheet.Cells["D3"].Value = "Giới tính";
                workSheet.Cells["E3"].Value = "Ngày sinh";
                workSheet.Cells["F3"].Value = "Số CMND";
                workSheet.Cells["G3"].Value = "";
                workSheet.Cells["H3"].Value = "Tên đơn vị";
                workSheet.Cells["I3"].Value = "Email";
                workSheet.Cells["J3"].Value = "Ngân hàng";
                workSheet.Cells["K3"].Value = "Chi nhánh";
                workSheet.Columns[1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Columns[5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Columns[6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Columns[5].Style.Numberformat.Format = "dd/mm/yyyy";
                workSheet.Cells["A3:K3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A3:K3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A3:K3"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ccc"));
              
                workSheet.Cells["A3:K3"].Style.Font.Bold = true;
                workSheet.Cells["A3:K3"].Style.Font.Size = 10;
                workSheet.Cells["A3:K3"].Style.Font.Name = "Arial";
                workSheet.Cells["A1"].Style.Font.Bold = true;
                workSheet.Cells["A1"].Style.Font.Size = 16;
                workSheet.Cells["A1"].Style.Font.Name = "Arial";
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Bottom.Color.SetColor(Color.Black);
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Bottom.Color.SetColor(Color.Black);
                     workSheet.Cells[$"A3:{cellLastBorder}"].Style.Border.Bottom.Color.SetColor(Color.Black);

                double minimumSize = 10;
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns(minimumSize);


                double maximumSize = 50;
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns(minimumSize, maximumSize);


                for (int col = 1; col <= workSheet.Dimension.End.Column; col++)
                {
                    workSheet.Column(col).Width = workSheet.Column(col).Width + 1;
                }
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/octet-stream", "DanhSachNhanVien.xlsx");
        }



        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns>
        /// input: recordStart (trang bắt đầu), recordEnd (trang cuối), totalRecord (tổng trang)
        /// output: Data (các bản ghi)
        /// </returns>
        /// CreatedBy:ND_Tuan(15/08/2022)
        [HttpGet("filter")]
        public IActionResult GetPaging(int pageIndex, int pageSize, string? filter)
        {
            try
            {
                var res = _employeeRepository.GetPaging(pageIndex, pageSize, filter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }

        #endregion
    }
}

using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using MySqlConnector;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region DECLARE
        ServiceResult _serviceResult;
        IEmployeeService _employeeService;

        IBaseRepository<Employee> _baseRepository;
        #endregion


        #region Contructor
        public EmployeesController(
            IBaseRepository<Employee> baseRepository,
            IEmployeeService employeeService) : base(employeeService, baseRepository)
        {
            _employeeService = employeeService;
            _serviceResult = new ServiceResult();
            _baseRepository = baseRepository;

        }
        #endregion

        #region Method
        /// <summary>
        /// Sinh mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created By : TTUyen ( 28/08/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var emoloyeeCode = _employeeService.GetNewEmployeeCode();
                _serviceResult.Data = emoloyeeCode;
                _serviceResult.Status = RequestStatus.Complete;
                return StatusCode(200, _serviceResult.Data);
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = ApplicationCore.Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }
        }


        /// <summary>
        /// Lấy danh sách nhân viên theo từng điều kiện lọc
        /// </summary>
        /// HTTPStatusCode - 200 : có dữ liệu trả về
        /// HTTPStatusCode - 204 : không có dữ liệu
        /// <returns>Danh sách nhân viên theo điều kiện lọc</returns>
        /// Created By : TTUyen ( 28/08/2021)

        [HttpGet("Filter")]
        public IActionResult GetEmployeesByPaging([FromQuery] EmployeeFilter employeeFilter)
        {
            try
            {
                var paging = _employeeService.GetEmployeesByPaging(employeeFilter);

                // Xử lý kết quả trả về cho client.
                if (paging.Data.Any())
                {
                    return StatusCode(200, paging);
                }

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var msgError = new
                {
                    devMsgVN = ex.Message,
                    userMsgVN = ApplicationCore.Properties.ResourcesVN.ErrorUserMsgExeption,
                };
                _serviceResult.Messager = ex.Message;
                _serviceResult.Data = msgError;
                _serviceResult.Status = RequestStatus.Exception;
                return StatusCode(500, _serviceResult);
            }

        }

        /// <summary>
        /// Hàm export ra file excel danh sách nhân viên
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>File excel</returns>
        /// Created By : TTUyen ( 28/08/2021)
        [HttpGet("Export")]
        public async Task<IActionResult> Export(CancellationToken cancellationToken)
        {
            // query data from database  
            await Task.Yield();

            // gọi lên service để lấy về list employee
            var employees = _baseRepository.Get();

            if (employees.Any())
            {
                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    //Đặt tên người tạo file
                    package.Workbook.Properties.Author = "UyenTT";
                    //Đặt tiêu đề cho file
                    package.Workbook.Properties.Title = "Danh sách nhân viên";
                    // tạo sheet 
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    // tạo fontsize và fontfamily cho sheet
                    workSheet.Cells.Style.Font.Size = 11;
                    workSheet.Cells.Style.Font.Name = "Times New Roman";

                    // danh sách các tên cột
                    string[] arrColumnHeader = {"STT", "Mã nhân viên","Tên nhân viên", "Giới tính", "Ngày sinh",
                   "Số CMND", "Chức danh", "Tên đơn vị", "Số tài khoản", "Tên ngân hàng", "Chi nhánh TK ngân hàng" };
                    // Gán row header
                    for (var i = 0; i < arrColumnHeader.Length; i++)
                    {
                        workSheet.Cells[3, i + 1].Value = arrColumnHeader[i];
                    }

                    // chỉnh style cho bảng
                    workSheet.Cells[1, 1].Value = "DANH SÁCH NHÂN VIÊN";
                    workSheet.Cells["A1:K1"].Merge = true;
                    workSheet.Cells[1, 1].Style.Font.Size = 16;
                    workSheet.Row(1).Style.Font.Bold = true;
                    workSheet.Row(1).Style.Font.Name = "Aria";
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells["A2:K2"].Merge = true;
                    workSheet.Row(2).Height = 20;
                  
                    workSheet.Cells["A3:K3"].Style.Font.Bold = true;
                    workSheet.Cells["A3:K3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#D9D9D9");
                    workSheet.Cells["A3:K3"].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    workSheet.Cells["A3:K3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                  
                    //Chỉnh độ rộng các cột
                    workSheet.Column(1).Width = 5;
                    workSheet.Column(2).Width = 15;
                    workSheet.Column(3).Width = 20;
                    workSheet.Column(4).Width = 10;
                    workSheet.Column(5).Width = 15;
                    workSheet.Column(6).Width = 20;
                    workSheet.Column(7).Width = 20;
                    workSheet.Column(8).Width = 20;
                    workSheet.Column(9).Width = 15;
                    workSheet.Column(10).Width = 15;
                    workSheet.Column(11).Width = 30;

                    // Gán data list vào sheet
                    var count = 1;
                    var rowIndex = 4;
                    foreach (var employee in employees)
                    {
                        workSheet.Cells[rowIndex, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[rowIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        workSheet.Cells[rowIndex, 1].Value = count;
                        workSheet.Cells[rowIndex, 2].Value = employee.EmployeeCode;
                        workSheet.Cells[rowIndex, 3].Value = employee.EmployeeName;
                        workSheet.Cells[rowIndex, 4].Value = employee.GenderName;
                        workSheet.Cells[rowIndex, 5].Value = Convert.ToDateTime(employee.DateOfBirth).ToString("dd/MM/yyyy");
                        workSheet.Cells[rowIndex, 6].Value = employee.IdentityNumber;
                        workSheet.Cells[rowIndex, 7].Value = employee.EmployeePosition;
                        workSheet.Cells[rowIndex, 8].Value = employee.DepartmentName;
                        workSheet.Cells[rowIndex, 9].Value = employee.BankAccountNumber;
                        workSheet.Cells[rowIndex, 10].Value = employee.BankName;
                        workSheet.Cells[rowIndex, 11].Value = employee.BankBranchName;
                        rowIndex++;
                        count++;
                    }
                    workSheet.Cells[$"A3:K{rowIndex-1}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A3:K{rowIndex-1}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A3:K{rowIndex-1}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A3:K{rowIndex-1}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"Danh_sach_nhan_vien_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                //return File(stream, "application/octet-stream", excelName);  
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            return StatusCode(204);
        }
        #endregion
    }

}

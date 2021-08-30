using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructor.Repository
{

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        #region Contructor

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion


        #region Method
        /// <summary>
        /// Hàm sinh mã mới cho nhân viên
        /// </summary>
        /// <returns>Chuỗi mã code mới</returns>
        /// CreateBy: TTUyen
        public string GetNewEmployeeCode()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                //Thực hiện lấy query lấy mã nhân viên mới từ csdl
                string sqlCommand = "SELECT EmployeeCode FROM Employee ORDER BY  LENGTH(EmployeeCode) DESC, EmployeeCode DESC LIMIT 1";
                var employeeCode = _dbConnection.QueryFirstOrDefault<string>(sqlCommand);
                return employeeCode;                                                                  
            }

        }

        /// <summary>
        ///  Lấy danh sách khách hàng theo từng điều kiện lọc
        /// </summary>
        /// <param name="filter">Object chứa nội dung lọc</param>
        /// <returns>Danh sách khách hàng theo điều kiện lọc</returns>
        /// Created By : TTUyen
        public Paging<Employee> GetEmployeesByPaging(EmployeeFilter filter)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                Paging<Employee> pageNew = new Paging<Employee>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pageIndex", filter.PageIndex);
                parameters.Add("@pageSize", filter.PageSize);
                parameters.Add("@keySearch", filter.KeySearch);

                parameters.Add("@totalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@totalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);
              
                var sqlCommand = "Proc_GetEmployeesByPaging";
                var employees = _dbConnection.Query<Employee>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                var totalPage = parameters.Get<int>("@totalPage");
                var totalRecord = parameters.Get<int>("@totalRecord");

                pageNew = new Paging<Employee>
                {
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    PageIndex = filter.PageIndex,
                    Data = employees,
                    PageSize = filter.PageSize
                };
                return pageNew;
            }
            #endregion
        }
    }
}

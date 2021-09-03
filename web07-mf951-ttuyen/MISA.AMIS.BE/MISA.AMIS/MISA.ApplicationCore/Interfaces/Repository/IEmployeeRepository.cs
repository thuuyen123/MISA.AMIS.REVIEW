using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repository
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {

        /// <summary>
        /// Sinh mã mới cho nhân viên
        /// Sinh mã mới cho nhân viên
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created By : TTUyen ( 28/08/2021)
        string GetNewEmployeeCode();

        /// <summary>
        ///  Lấy danh sách khách hàng theo từng điều kiện lọc
        /// </summary>
        /// <param name="filter">Object chứa nội dung lọc</param>
        /// <returns>Danh sách khách hàng theo điều kiện lọc</returns>
        /// Created By : TTUyen
        public Paging<Employee> GetEmployeesByPaging(EmployeeFilter filter);


    }
}

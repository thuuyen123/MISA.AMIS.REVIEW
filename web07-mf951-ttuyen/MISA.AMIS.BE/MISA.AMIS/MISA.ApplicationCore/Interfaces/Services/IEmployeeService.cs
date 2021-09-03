using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService: IBaseService<Employee>
    {

        #region METHOD
        /// <summary>
        /// Tạo mã mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        ///Created By : TTUyen ( 28/08/2021)
        string GetNewEmployeeCode();

        /// <summary>
        ///  Lấy danh sách khách hàng theo từng điều kiện lọc
        /// </summary>
        /// <param name="filter">Object chứa nội dung lọc</param>
        /// <returns>Danh sách khách hàng theo điều kiện lọc</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public Paging<Employee> GetEmployeesByPaging(EmployeeFilter filter);
        #endregion

    }
}

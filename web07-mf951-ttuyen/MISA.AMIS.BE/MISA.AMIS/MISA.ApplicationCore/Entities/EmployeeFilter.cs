using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Phân trang và lọc nhân viên
    /// Created By : TTUyen (22/08/2021)
    /// </summary>
    public class EmployeeFilter
    {
        /// <summary>
        /// Trang hiện tại
        /// Created By : TTUyen (22/08/2021)
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Số lượng bản ghi có trong Page
        /// Created By : TTUyen (22/08/2021)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Lọc theo CustomerCode hay PhoneNumber hay FullName
        /// Created By : TTUyen (22/08/2021)
        /// </summary>
        public string KeySearch { get; set; } = "";


    }
}

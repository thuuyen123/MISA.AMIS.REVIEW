using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class Department : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        ///Created By : TTUyen ( 28/08/2021)
        [DisplayName("Khóa chính")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        ///Created By : TTUyen ( 28/08/2021)
        [DisplayName("Mã đơn vị")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        ///Created By : TTUyen ( 28/08/2021)
        [DisplayName("Tên đơn vị")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        ///Created By : TTUyen ( 28/08/2021)
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        #endregion
    }

}

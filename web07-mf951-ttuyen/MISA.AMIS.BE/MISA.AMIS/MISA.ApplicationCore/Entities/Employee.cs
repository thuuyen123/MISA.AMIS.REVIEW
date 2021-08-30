using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class Employee : BaseEntity
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Khóa chính")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        /// CreateBy: TTUyen
        [Duplicated]
        [Required]
        [MaxLength(20, "Mã nhân viên không được quá 20 ký tự")]
        [DisplayName("Mã nhân viên ")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        /// CreateBy: TTUyen
        [Required]
        [DisplayName("Tên nhân viên ")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }


        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Giới tính")]
        public int? Gender { get; set; }

        /// <summary>
        /// Tên giới tính
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Tên giới tính")]
        public string GenderName
        {
            get
            {
                if (Gender == 0)
                {
                    return "Nữ";
                }
                else if (Gender == 1)
                {
                    return "Nam";
                }
                return "Khác";
            }
        }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreateBy: TTUyen
        [Required]
        [DisplayName("Id đơn vị")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Tên đơn vị")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Số chứng minh thư/căn cước công dân
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Số chứng minh thư / Căn cước công dân của nhân viên ")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp cmt
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Ngày cấp CMND")]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp 
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Nơi cấp CMTND")]
        public string IdentityPlace { get; set; }


        /// <summary>
        /// đơn vị công việc
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("đơn vị")]
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Tài khoản ngân hàng")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Tên ngân hàng")]
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Chi nhánh ngân hàng")]
        public string BankBranchName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Địa chỉ nhân viên ")]
        public string Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreateBy: TTUyen
        [FormatEmail]
        [DisplayName("Email nhân viên ")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Sdt di động của nhân viên ")]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Sdt di động của nhân viên ")]
        public string LandlineNumber { get; set; }

        #endregion
    }
}

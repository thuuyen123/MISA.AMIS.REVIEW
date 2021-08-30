﻿using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class BaseEntity
    {
        #region Property
  
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Ngày sửa")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Chỉnh sửa bởi
        /// </summary>
        /// CreateBy: TTUyen
        [DisplayName("Người sửa")]
        public string ModifiedBy { get; set; }

        #endregion
    }
}

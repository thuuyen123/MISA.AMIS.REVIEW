using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.Interfaces.Services;
using MISA.ApplicationCore.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {

        private IBaseRepository<TEntity> _baseRepository;

        private ServiceResult _serviceResult;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { ErrorCode = MISACode.Success };
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity">Object bản ghi</param>
        /// <returns>Kết quả</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public virtual ServiceResult Add(TEntity entity)
        {
            //Đánh đấu đang ở trạng thái thêm mới
            entity.EntityState = EntityState.AddNew;
            var isValid = ValidateData(entity);
            if (isValid == true)
            {
                //Số bản ghi thêm thành công
                var rowEffect = _baseRepository.Add(entity);
                if (rowEffect > 0)
                {
                    _serviceResult.Messager = Properties.ResourcesVN.AddComplete;
                    _serviceResult.ErrorCode = MISACode.IsValid;
                    _serviceResult.Data = rowEffect;
                }
                else
                {
                    _serviceResult.Messager = Properties.ResourcesVN.NoAddInDataBase;
                    _serviceResult.Data = rowEffect;
                }
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>ServiceResulf: object kết quả</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public ServiceResult Delete(Guid entityId)
        {
            var res = _baseRepository.Delete(entityId);
            _serviceResult.Data = res;
            _serviceResult.ErrorCode = MISACode.IsValid;
            return _serviceResult;
        }

        /// <summary>
        /// Danh sách bản ghi
        /// </summary>
        /// <returns></returns>
        /// Created By : TTUyen ( 28/08/2021)
        public IEnumerable<TEntity> Get()
        {
            return _baseRepository.Get();
        }

        /// <summary>
        /// Lọc nhân viên
        /// </summary>
        /// <param name="propName">Tên thuộc tính</param>
        /// <param name="propValue">Giá trị thuộc tính</param>
        /// <returns>Bản ghi tương ứng</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public TEntity GetByProp(TEntity entity, PropertyInfo property)
        {
            return _baseRepository.GetByProp(entity, property);
        }

        /// <summary>
        /// Lọc bản ghi theo id
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>Bản ghi tương ứng</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public TEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="entity">Object cập nhật</param>
        /// <param name="entityId">id</param>
        /// <returns>Kết quả ServiceResult</returns>
        /// Created By : TTUyen ( 28/08/2021)
        public virtual ServiceResult Update(TEntity entity, Guid entityId)
        {
            entity.EntityState = EntityState.Update;
            var isValid = ValidateData(entity);
            if (isValid == true)
            {
                // số bản ghi cập nhật thành công
                var rowEffect = _baseRepository.Update(entity, entityId);
                if (rowEffect > 0)
                {
                    _serviceResult.Messager = Properties.ResourcesVN.UpdateComplete;
                    _serviceResult.ErrorCode = MISACode.IsValid;
                    _serviceResult.Data = rowEffect;
                }
                else
                {
                    _serviceResult.Messager = Properties.ResourcesVN.NoUpdateInDataBase;
                    _serviceResult.Data = rowEffect;
                }
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }

        }

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="formMode">Để kiểm tra xem nó là add hay update</param>
        /// <returns>True/False</returns>
        /// Created By : TTUyen ( 28/08/2021)
        private bool ValidateData(TEntity entity)
        {
            var isValidated = true;
            var mesError = new List<string>();
            //Lấy ra tất cả các property của class
            var properties = typeof(TEntity).GetProperties();
            var devMsg = new List<String>();
            var userMsg = new List<String>();
            foreach (var property in properties)
            {
                //lấy giá trị của property
                var propertyValue = property.GetValue(entity);

                var propName = property.Name;
            
                //Tên đã được gắn ở đối tượng để trả về lỗi 
                var displayName = property.GetCustomAttributes(typeof(DisplayName), true);
         
                //khởi tạo giá trị cho name
                var name = string.Empty;

                //trả về tên của thuộc tính của tất cả các trường đã gán
                if (displayName.Length > 0)
                    name = (displayName[0] as DisplayName).Name;

                //Kiểm tra các thuộc tính bắt buộc
                if (property.IsDefined(typeof(Required), true))
                {
                    //Check bắt buộc nhập
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {

                        devMsg.Add(Properties.ResourcesVN.ErrorDevMsgRequire);
                        userMsg.Add(Properties.ResourcesVN.ErrorUserMsgRequire);
                        mesError.Add(string.Format(Properties.ResourcesVN.ErrorDevMsgRequire, name));
                 
                        _serviceResult.ErrorCode = MISACode.NoValid;
                        isValidated = false;
                    }
                }
                if (property.IsDefined(typeof(Duplicated), true))
                {

                    var entityByProp = GetByProp(entity, property);

                    if (entityByProp != null)
                    {
                        devMsg.Add(string.Format(Properties.ResourcesVN.ErrorDevMsgDuplicate, name));
                    
                        userMsg.Add(string.Format(Properties.ResourcesVN.ErrorUserMsgDuplicateCode, propertyValue.ToString()));
                        
                        mesError.Add(string.Format(Properties.ResourcesVN.ErrorDevMsgDuplicate, name));
                        
                        _serviceResult.ErrorCode = MISACode.NoValid;
                        
                        isValidated = false;
                    }
                }
                //check độ dài
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    // lấy ra độ dài khai báo
                  
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    
                    var length = (attributeMaxLength as MaxLength).Length;
                    
                    var msg = (attributeMaxLength as MaxLength).ErrorMsg;
                    
                    if (propertyValue.ToString().Trim().Length > length)
                    {
                        isValidated = false;
                        mesError.Add(msg);
                        _serviceResult.ErrorCode = MISACode.NoValid;
                    }
                }
                //format email
                if (property.IsDefined(typeof(FormatEmail), false))
                {
                    if (!string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var emailFormat = @"^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
                      
                        var isMatch = Regex.IsMatch(propertyValue.ToString(), emailFormat, RegexOptions.IgnoreCase);
                        
                        if (isMatch == false)
                        {

                            devMsg.Add(string.Format(Properties.ResourcesVN.ErrorDevMsgValidate, name));
                           
                            userMsg.Add(string.Format(Properties.ResourcesVN.ErrorUserMsgValidate, name));
                            
                            isValidated = false;
                            
                            mesError.Add(string.Format(Properties.ResourcesVN.ErrorUserMsgValidate, name));
                            
                            _serviceResult.ErrorCode = MISACode.NoValid;

                        }
                    }
                }
            }
            var data = new
            {
                devMsg = devMsg,
                userMsg = userMsg,

            };
            _serviceResult.Data = data;
            _serviceResult.Messager = mesError;
            return isValidated;
        }
        /// <summary>
        /// Hàm validate custom
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        /// Created By : TTUyen ( 28/08/2021)
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
    }
}

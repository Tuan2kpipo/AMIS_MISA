using MISA.Web06.Core.Exceptions;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.MISAAttribute;
using MISA.Web06.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Fields
        // thực hiện tương tác vs base
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Contructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Insert
        /// </summary>
        /// <returns>
        /// recordStart (trang bắt đầu), recordEnd (trang cuối), totalRecord (tổng trang)
        /// Data (các bản ghi)
        /// CreatedBy: ND_Tuan(15/08/2022)
        public int InsertService(MISAEntity entity)
        {

            //Validate dữ liệu
            ValidateData(entity);

            ValidateEmployee(entity);

            ///xử lý nghiệp vụ
            ///Thêm mới dl
            var res = _baseRepository.Insert(entity);
            return res;
        }


        /// <summary>
        /// Validate chung
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="MISAValidateException"></exception>
        /// CreatedBy: ND_Tuan(15/08/2022)
        private void ValidateData(MISAEntity entity)
        {

            //phương thức để đọc tất các props của {} đc khởi tạo
            var props = entity.GetType().GetProperties();
            //Lấy các property được đánh dấu là k đc phép bỏ trống - có attribute
            var propNotEmpties = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(NotEmpty)));

            foreach (var prop in propNotEmpties)
            {
                var propValue = prop.GetValue(entity);
                var nameDisplay = string.Empty;
                var propName = prop.Name;
                //lấy ra tên của property
                var propertyNames = prop.GetCustomAttributes(typeof(ProppertyName), true);

                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as ProppertyName).Name;
                }

                if (propValue == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);
                    throw new MISAValidateException(String.Format(Core.Resources.ResourceVN.InfoNotEmpty, nameDisplay));
                }
            }
        }

       //validate riêng
       protected virtual void ValidateEmployee(MISAEntity entity)
            {

               
            }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="MISAValidateException"></exception>
        /// CreatedBy: ND_Tuan(15/08/2022)
        public int UpdateService(MISAEntity entity)
        {
            //validate dữ liệu
            //Thực hiện thêm mới
            var res = _baseRepository.Update(entity);
            return res;
        }




        #endregion
    }
}

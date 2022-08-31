using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web06.Core.Exceptions;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.Services;

namespace MISA.Web06.ApiFnial.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Fields
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Contructor
        public BaseController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion



        #region Methods

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>200- nếu có dl danh sách
        /// 400-lỗi nghiệp vụ
        /// 500-nếu có exception
        /// </returns>
        /// CreatedBy: ND_Tuan(14/08/2022)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _baseRepository.GetAll();
                return Ok(data);
            }
            catch(MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }


        /// <summary>
        /// Lấy dl theo Id
        /// </summary>
        /// <returns>200- nếu có dl danh sách
        /// 400-lỗi nghiệp vụ
        /// 500-nếu có exception
        /// </returns>
        /// CreatedBy: ND_Tuan(14/08/2022)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                var data = _baseRepository.GetById(entityId);
                return Ok(data);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <returns>
        /// </returns>
        /// CreatedBy:ND_Tuan(15/08/2022)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            try
            {
                var data = _baseService.InsertService(entity);
                return StatusCode(201, data);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);

            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }


        /// <summary>
        /// Sửa
        /// </summary>
        /// <returns>
        /// </returns>
        /// CreatedBy:ND_Tuan(15/08/2022)
        [HttpPut]
        public IActionResult Put(MISAEntity entity)
        {
            try
            {
                var res = _baseService.UpdateService(entity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }


        /// <summary>
        /// Xóa bản ghi theo ID
        /// </summary>
        /// <returns>
        /// </returns>
        /// CreatedBy:ND_Tuan(15/08/2022)
        /// <summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = _baseRepository.Delete(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resources.ResourceVN.ErrorException,
                    data = ex.InnerException,
                };
                return StatusCode(500, response);
            }
        }



        #endregion
    }
}

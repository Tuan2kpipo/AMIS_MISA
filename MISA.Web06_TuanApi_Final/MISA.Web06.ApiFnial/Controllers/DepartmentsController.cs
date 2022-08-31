using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web06.Core.Entities;
using MISA.Web06.Core.Exceptions;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.Services;

namespace MISA.Web06.ApiFnial.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController<Department>
    {
        #region Fields
        IDepartmentRepository _departmentRepository;
        IDepartmentService _departmentService;
        #endregion

        #region Contructor
        public DepartmentsController(IDepartmentRepository departmentRepository, IDepartmentService departmentService):base(departmentService, departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;

        }
        #endregion
    }
}

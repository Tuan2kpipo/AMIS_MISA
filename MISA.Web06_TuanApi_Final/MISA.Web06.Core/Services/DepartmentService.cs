using MISA.Web06.Core.Entities;
using MISA.Web06.Core.Interface.Insfrastructure;
using MISA.Web06.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Services
{
   public class DepartmentService:BaseService<Department>, IDepartmentService
    {
        #region Fields
        IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository):base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}

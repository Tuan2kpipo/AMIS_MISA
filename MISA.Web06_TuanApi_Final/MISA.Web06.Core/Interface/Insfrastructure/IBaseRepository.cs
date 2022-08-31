using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Interface.Insfrastructure
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(10/08/2022)
        IEnumerable<MISAEntity> GetAll();

        /// <summary>
        /// Them
        /// </summary>
        /// <param name="department"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Lay theo Id
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        MISAEntity GetById(Guid entity);

        /// <summary>
        /// Sua
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        int Update(MISAEntity entity);


        /// <summary>
        /// Sua
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: ND_Tuan(09/08/2022)
        /// <returns></returns>
        int Delete(Guid entityId);



    }
}

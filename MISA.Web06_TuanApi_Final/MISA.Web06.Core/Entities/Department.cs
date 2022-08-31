using MISA.Web06.Core.Interface.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Entities
{
    public class Department : BaseEntities
    {
        /// <summary>
        /// ID Phòng ban
        /// </summary>
        [PrimaryKey]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
       
        public string? DepartmentName { get; set; }



    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.Core.Interface.Services
{
   public interface IBaseService<MISAEntity>
    {
        int InsertService(MISAEntity entity);

        int UpdateService(MISAEntity entity);


    }

}

﻿using API_Assesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Services.Interfaces
{
    public interface IRoleTypeService : IRepository<RoleType>
    {
        Task<RoleType> Update(RoleType entity);
    }
}

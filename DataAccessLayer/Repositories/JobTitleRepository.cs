﻿using DataAccessLayer.Repositories.Interface;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class JobTitleRepository:GenericRepository<JobTitle>,IJobTitleDal
    {
    }
}

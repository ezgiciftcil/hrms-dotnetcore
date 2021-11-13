using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IJobTitleService
    {
        Result AddJobTitle(JobTitle jobTitle);
        Result UpdateJobTitle(JobTitle jobTitle);
        Result DeleteJobTitle(JobTitle jobTitle);
        DataResult<List<JobTitle>> GetAllJobTitles();
        DataResult<JobTitle> GetJobTitleById(int id);
    }
}

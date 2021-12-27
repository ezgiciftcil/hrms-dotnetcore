using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IResumeService
    {
        Result AddResume(Resume resume);
        Result UpdateResume(Resume resume);
        Result DeleteResume(Resume resume);
        DataResult<List<Resume>> GetAllResumes();
        DataResult<Resume> GetResumeById(int id);
    }
}

using EntityLayer;

namespace DataAccessLayer.Interfaces
{
    public interface IResumeDal:IGenericDal<Resume>
    {
        int GetJobSeekerResumeId(int JobSeekerId);
    }
}

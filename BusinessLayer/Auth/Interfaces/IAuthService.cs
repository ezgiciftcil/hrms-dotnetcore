using BusinessLayer.Auth.DTOs;
using BusinessLayer.Utilities.Results;

namespace BusinessLayer.Auth.Interfaces
{
    public interface IAuthService
    {
        Result RegisterJobSeeker(JobSeekerDTO jobSeeker);
        Result RegisterEmployer(EmployerDTO employer);
        Result Login(UserDTO user);
        int GetUserId(string email);
    }
}

using BusinessLayer.Auth.DTOs;
using BusinessLayer.Auth.Interfaces;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;

namespace BusinessLayer.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJobSeekerService _jobSeekerService;
        private readonly IResumeService _resumeService;
        public readonly IEmployerService _employerService;
        public AuthService(IUserService userService, IJobSeekerService jobSeekerService,IResumeService resumeService, IEmployerService employerService)
        {
            _userService = userService;
            _jobSeekerService = jobSeekerService;
            _resumeService = resumeService;
            _employerService = employerService;
        }
        

        public Result RegisterJobSeeker(JobSeekerDTO jobSeeker)
        {
            if ((_userService.IsEmailExist(jobSeeker.Email)))
            {
                return new Result(false, "An account already created with this email.");
            }
            if (jobSeeker.Password != jobSeeker.PasswordRepeat)
            {
                return new Result(false, "Please enter the same password.");
            }
            var newUser = new User() { 
                Email = jobSeeker.Email, 
                Password = jobSeeker.Password };

            if (!(_userService.AddUser(newUser).Success))
            {
                return new Result(false, _userService.AddUser(newUser).Message);
            }
            var newJobSeeker = new JobSeeker { 
                UserId = _userService.GetIdByEmail(jobSeeker.Email), 
                FirstName = jobSeeker.FirstName, 
                LastName = jobSeeker.LastName, 
                PhoneNumber = jobSeeker.PhoneNumber };
            if (!(_jobSeekerService.AddJobSeeker(newJobSeeker)).Success)
            {
                return new Result(false, _jobSeekerService.AddJobSeeker(newJobSeeker).Message);
            }
            var newResume = new Resume { UserId = _userService.GetIdByEmail(jobSeeker.Email) };
            _resumeService.AddResume(newResume);
            return new Result(true, "Job Seeker Account Has Been Created.");

        }

        public Result RegisterEmployer(EmployerDTO employer)
        {
            if ((_userService.IsEmailExist(employer.Email)))
            {
                return new Result(false, "An account already created with this email.");
            }
            if (employer.Password != employer.PasswordRepeat)
            {
                return new Result(false, "Please enter the same password.");
            }
            var newUser = new User
            {
                Email = employer.Email,
                Password = employer.Password
            };
            if (!(_userService.AddUser(newUser).Success))
            {
                return new Result(false, (_userService.AddUser(newUser).Message));
            }
            var newEmployer = new Employer
            {
                CompanyName = employer.CompanyName,
                CompanyWebsite = employer.CompanyWebsite,
                ContactNumber = employer.ContactNumber,
                UserId = _userService.GetIdByEmail(employer.Email)
            };
            if (!(_employerService.AddEmployer(newEmployer).Success))
            {
                return new Result(false, (_employerService.AddEmployer(newEmployer).Message));
            }
            return new Result(true, "Employer Account Has Been Created");
        }

        public Result Login(UserDTO user)
        {
            if (!(_userService.IsEmailExist(user.Email))){
                return new Result(false, "Wrong Email or Password");
            }
            var passwordToCheck = user.Password;
            var passwordUser = _userService.GetPasswordByEmail(user.Email);
            if (!(passwordToCheck == passwordUser))
            {
                return new Result(false, "Wrong Email or Password");
            }
            return new Result(true);
        }

        public int GetUserId(string email)
        {
            return _userService.GetIdByEmail(email);
        }
        
    }
}

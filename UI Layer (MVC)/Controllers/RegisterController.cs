using BusinessLayer.Auth.DTOs;
using BusinessLayer.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthService _registerService;
        public RegisterController(IAuthService registerService)
        {
            _registerService = registerService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult JobSeekerRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JobSeekerRegister(JobSeekerRegister jobSeeker)
        {
            var newJobSeeker = new JobSeekerDTO {
                Email = jobSeeker.Email,
                FirstName = jobSeeker.FirstName,
                LastName = jobSeeker.LastName,
                Password = jobSeeker.Password,
                PasswordRepeat=jobSeeker.PasswordRepeat,
                PhoneNumber=jobSeeker.PhoneNumber
            };
            var result=_registerService.RegisterJobSeeker(newJobSeeker);
            if (result.Success)
            {
                return RedirectToAction("Index", "Test");
            }
            return View();
                
        }


        [HttpPost]
        public IActionResult EmployerRegister(EmployerRegister employer)
        {
            var newEmployer = new EmployerDTO
            {
                Email = employer.Email,
                CompanyName = employer.CompanyName,
                CompanyWebsite = employer.CompanyWebsite,
                ContactNumber = employer.ContactNumber,
                Password = employer.Password,
                PasswordRepeat = employer.PasswordRepeat
            };
            var result = _registerService.RegisterEmployer(newEmployer);
            if (result.Success)
            {
                return RedirectToAction("Index", "Test");
            }
            return View();
        }

        public IActionResult EmployerRegister()
        {
            return View();
        }


    }
}

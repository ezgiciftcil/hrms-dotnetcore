using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Result AddUser(User user)
        {
            if (user.Email == null)
            {
                return new Result(false, "Please Enter Your Email Adress.");
            }
            if(!(user.Password.Length >= 8 && user.Password.Length <= 12))
            {
                return new Result(false, "Password must be between 8 and 12 character lengths!");
            }
            user.IsActive = true;
            user.CreateDate = DateTime.Now;
            _userDal.Add(user);
            return new Result(true, "User is added!");
        }

        public Result DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new Result(true, "User is deleted.");
        }

        public DataResult<List<User>> GetAllUsers()
        {
            return new DataResult<List<User>>(_userDal.GetAll(), true, "All active/inactive users are listed.");
        }

        public DataResult<User> GetUserById(int id)
        {
            return new DataResult<User>(_userDal.GetById(id), true, "The user is listed.");
        }

        public Result UpdateUser(User user)
        {
            _userDal.Update(user);
            return new Result(true, "The user updated.");
        }
    }
}

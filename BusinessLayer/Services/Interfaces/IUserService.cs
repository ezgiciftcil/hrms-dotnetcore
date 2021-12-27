using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Result AddUser(User user);
        Result UpdateUser(User user);
        Result DeleteUser(User user);
        DataResult<List<User>> GetAllUsers();
        DataResult<User> GetUserById(int id);
    }
}

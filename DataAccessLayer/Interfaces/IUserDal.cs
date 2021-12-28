using EntityLayer;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDal:IGenericDal<User>
    {
        int GetIdByEmail(string email);
        string GetPasswordByEmail(string email);
        int IsEmailExist(string email);
    }
}

using Scheduler.Core.Models;
using System.Data;

namespace Scheduler.Core.Interfaces
{
    public interface IDataService
    {
        DataTable GetAllUsers();
        void CreateUser(User user);
        User GetUserByUsername(string username);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}

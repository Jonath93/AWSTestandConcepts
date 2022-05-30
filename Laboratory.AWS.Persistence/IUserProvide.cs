using Laboratory.AWS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laboratory.AWS.Persistence
{
    public interface IUserProvide
    {
        Task<List<Users>> GetUsersList();
    }
}
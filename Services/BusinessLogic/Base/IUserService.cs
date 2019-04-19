using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.BusinessLogic.Base
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library.Abstract
{
    interface iUserProvider
    {
        string GetName(int id);
        DateTime GetDateCreate(int id);
        int GetId(string name);
        IList<tblUser> GetAllUsers();
        tblUser AddUser(object name);
    }
}

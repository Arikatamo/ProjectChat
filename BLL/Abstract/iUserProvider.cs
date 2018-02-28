using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Library;
namespace BLL.Abstract
{
    public interface iUserProvider
    {
        tblUser AddUser(string name, string phone, string image);
        IList<tblUser> GetAllContacts(tblUser user);
        void AddContacts(tblUser user, tblUser UserToAdd);
        IList<tblUser> GetAllUsers();
        /////
    }
}
